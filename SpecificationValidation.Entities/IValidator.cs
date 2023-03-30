namespace SpecificationValidation.Entities;
public interface IValidator<T>
{
    IValidationResult Validate(T entity);
    IValidationResult ValidateProperty(T entity, string propertyName);
    void Guard(T entity);
}


