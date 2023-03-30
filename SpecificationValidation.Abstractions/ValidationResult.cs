namespace SpecificationValidation.Abstractions;
public class ValidationResult : IValidationResult
{
    public bool IsValid => !ErrorsField.Any();
    public IEnumerable<IValidationError> Errors => ErrorsField;
    public override string ToString() =>
            string.Join(" ", ErrorsField.Select(e => e.Message));

    readonly List<IValidationError> ErrorsField = new();
    internal void AddRange(IEnumerable<IValidationError> errors) =>
        ErrorsField.AddRange(errors);
}
