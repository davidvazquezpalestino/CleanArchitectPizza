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
        ValidationResult validationResult = new();
        foreach (var specification in Specifications)
        {
            bool isSatisfied = propertyName == null ?
                specification.IsSatisfiedBy(entity) :
                specification.IsSatisfiedBy(entity, propertyName);
            if (!isSatisfied)
            {
                validationResult.AddRange(specification.Errors);
            }
        }
        return validationResult;
    }

    public void Guard(T entity)
    {
        IValidationResult result = Validate(entity);
        if (!result.IsValid)
            throw new ValidationException(result);
    }
}
