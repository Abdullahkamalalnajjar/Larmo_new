namespace Larmo.Shared.Exceptions.ErrorModels;

public class ErrorProperty
{
    public ErrorProperty()
    {
    }

    public ErrorProperty(object value, string errorCode, string message, string severity)
    {
        Value = value;
        ErrorCode = errorCode;
        Message = message;
        Severity = severity;
    }

    public object Value { get; set; }

    public string ErrorCode { get; set; }

    public string Message { get; set; }

    public string Severity { get; set; }
}