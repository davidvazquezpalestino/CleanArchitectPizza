namespace SpecificationValidation.Abstractions;
public class ValidationError : IValidationError
{
    public string Message { get; }
    public string PropertyName { get; }
    internal ValidationError(string propertyName, string message) =>
        (PropertyName, Message) = (propertyName, message);
}
