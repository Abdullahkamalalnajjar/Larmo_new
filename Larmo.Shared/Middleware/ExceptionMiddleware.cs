using System.Data.Common;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using DateOnlyTimeOnly.AspNet.Converters;
using FluentValidation;
using Larmo.Shared.Exceptions.ErrorModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Larmo.Shared.Middleware;

public class ExceptionMiddleware(ILogger<ExceptionMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);

            if (e.GetBaseException() is ValidationException || e is ValidationException)
            {
                await HandleValidationException(context, e);
            }
            else if (e.GetBaseException() is DbException || e is DbException ||
                     e.GetBaseException() is DbUpdateException || e is DbUpdateException)
            {
                await HandleDatabaseException(context, e);
            }
            else if (e.GetBaseException() is SecurityTokenException || e is SecurityTokenException)
            {
                await HandleSecurityTokenException(context);
            }
            else
            {
                await HandleUnexpectedExceptions(context, e);
            }
        }
    }

    private async Task HandleValidationException(HttpContext context, Exception e)
    {
        ErrorModel error = new();
        var exception = (ValidationException)e;
        error.Message = string.Empty;

        if (exception.Errors.Count() == 1)
        {
            error.Message = exception.Errors.Any() ? exception.Errors.First().ErrorMessage : exception.Message;
        }

        error.ExceptionType = nameof(ValidationException);

        var errorProperties = exception.Errors.GroupBy(c => c.PropertyName);
        foreach (var errorProperty in errorProperties)
        {
            ValidationError validationError = new()
            {
                PropertyName = errorProperty.Key
            };
            foreach (var validationFailure in errorProperty)
            {
                validationError.Validations.Add(new ErrorProperty(validationFailure.AttemptedValue,
                    ConvertToExceptionSuffix(validationFailure.ErrorCode), validationFailure.ErrorMessage,
                    validationFailure.Severity.ToString()));
            }

            error.Errors.Add(validationError);
        }

        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(JsonSerializer.Serialize(error, GetJsonSerializerOptions()), Encoding.UTF8);
    }

    private async Task HandleDatabaseException(HttpContext context, Exception exception)
    {
        ErrorModel error = new()
        {
            Message = exception.InnerException is not null ? exception.InnerException.Message : exception.Message,
            ExceptionType = nameof(DbException)
        };

        error.StatusCode = (int)HttpStatusCode.Conflict;
        context!.Response.StatusCode = (int)HttpStatusCode.Conflict;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(JsonSerializer.Serialize(error, GetJsonSerializerOptions()), Encoding.UTF8);
    }

    private static async Task HandleSecurityTokenException(HttpContext context)
    {
        context!.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        await context.Response.CompleteAsync();
    }

    private async Task HandleUnexpectedExceptions(HttpContext context, Exception exception)
    {
        ErrorModel error = new()
        {
            Message = exception.Message,
            ExceptionType = "InternalServerException"
        };

        error.StatusCode = (int)HttpStatusCode.InternalServerError;
        context!.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(JsonSerializer.Serialize(error, GetJsonSerializerOptions()), Encoding.UTF8);
    }

    private static JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters =
            {
                new TimeOnlyJsonConverter(),
                new DateOnlyJsonConverter(),
                new JsonStringEnumConverter()
            },
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
    }

    private static string ConvertToExceptionSuffix(string validatorError)
    {
        return validatorError.Replace("Validator", "Exception");
    }
}