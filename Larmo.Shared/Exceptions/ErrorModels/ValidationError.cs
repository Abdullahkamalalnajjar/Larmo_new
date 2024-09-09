namespace Larmo.Shared.Exceptions.ErrorModels;

public class ValidationError
{
    public ValidationError()
    {
    }

    public ValidationError(string propertyName, List<ErrorProperty> validations)
    {
        PropertyName = propertyName;
        Validations = validations;
    }

    public string PropertyName { get; set; }

    public List<ErrorProperty> Validations { get; set; } = new();
}