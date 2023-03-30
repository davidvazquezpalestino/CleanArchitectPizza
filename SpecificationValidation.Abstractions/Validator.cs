namespace SpecificationValidation.Abstractions;
public abstract class Validator<T> : IValidator<T>
{
    public Validator(IEnumerable<ISpecification<T>> specifications) =>
        Specifications = specifications;
    public IValidationResult Validate(T entity) =>
        ValidateEntityOrProperty(entity);
    public IValidationResult ValidateProperty(T entity, string propertyName) =>
        ValidateEntityOrProperty(entity, propertyName);

    readonly IEnumerable<ISpecification<T>> Specifications;
    ValidationResult ValidateEntityOrProperty(T entity, string propertyName = null)
    {
        ValidationResult ValidationResult = new();
        foreach (var Specification in Specifications)
        {
            bool IsSatisfied = propertyName == null ?
                Specification.IsSatisfiedBy(entity) :
                Specification.IsSatisfiedBy(entity, propertyName);
            if (!IsSatisfied)
            {
                ValidationResult.AddRange(Specification.Errors);
            }
        }
        return ValidationResult;
    }

    public void Guard(T entity)
    {
        var Result = Validate(entity);
        if (!Result.IsValid)
            throw new ValidationException(Result);
    }
}
