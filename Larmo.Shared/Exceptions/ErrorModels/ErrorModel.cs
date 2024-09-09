using System.Net;

namespace Larmo.Shared.Exceptions.ErrorModels;

public class ErrorModel
{
    public string ErrorCode { get; set; }

    public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;

    public string ExceptionType { get; set; }

    public string Message { get; set; }

    public List<ValidationError> Errors { get; set; } = new();

    public Exception InnerException { get; set; }

    public string StackTrace { get; set; }
}