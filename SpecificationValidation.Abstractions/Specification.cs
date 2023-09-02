namespace SpecificationValidation.Abstractions;
public abstract class Specification<T> : ISpecification<T>
{
    public IEnumerable<IValidationError> Errors => ErrorsField;
    public bool IsSatisfiedBy(T entity) =>
        ValidateRules(entity, PropertyRules);
    public bool IsSatisfiedBy(T entity, string propertyName) =>
        ValidateRules(entity,
            PropertyRules.Where(pr => pr.PropertyName == propertyName).ToList());
    protected PropertyRule<T> Property(Expression<Func<T, object>> property)
    {
        var propertyRule = new PropertyRule<T>(
            ExpressionHelper.GetPropertyName(property));

        PropertyRules.Add(propertyRule);
        return propertyRule;
    }
    readonly List<ValidationError> ErrorsField = new();
    readonly List<PropertyRule<T>> PropertyRules = new();

    bool ValidateRules(T entity, List<PropertyRule<T>> propertyRules)
    {
        ErrorsField.Clear();
        foreach (var property in propertyRules)
        {
            foreach (var rule in property.Rules)
            {
                if (!rule.Predicate(entity))
                {
                    ErrorsField.Add(new ValidationError(
                        property.PropertyName, rule.ErrorMessage));
                    if (property.OnFirstErrorAction ==
                        OnFirstErrorAction.StopValidation)
                    {
                        break;
                    }
                }
            }
        }
        return !ErrorsField.Any();
    }
}
