using Larmo.Core;
using Larmo.Infrastructure;
using System.Text.Json.Serialization;
using Larmo.Configurations.Cors;
using Larmo.Infrastructure.Context;
using Larmo.Shared;
using Larmo.Shared.Extension;
using Larmo.Shared.Middleware;
using Larmo.Configurations.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwagger();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCorsSetup(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCore(builder.Configuration);
builder.Services.AddShared();
builder.Services.AddSingleton<ExceptionMiddleware>();

var app = builder.Build();

app.UseExceptionMiddleware();
app.UseAutomaticMigration<ApplicationContext>();
app.UseCorsSetup();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
