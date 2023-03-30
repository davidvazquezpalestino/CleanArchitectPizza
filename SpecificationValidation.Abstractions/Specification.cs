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
        var PropertyRule = new PropertyRule<T>(
            ExpressionHelper.GetPropertyName(property));

        PropertyRules.Add(PropertyRule);
        return PropertyRule;
    }
    readonly List<ValidationError> ErrorsField = new();
    readonly List<PropertyRule<T>> PropertyRules = new();

    bool ValidateRules(T entity, List<PropertyRule<T>> propertyRules)
    {
        ErrorsField.Clear();
        foreach (var Property in propertyRules)
        {
            foreach (var Rule in Property.Rules)
            {
                if (!Rule.Predicate(entity))
                {
                    ErrorsField.Add(new ValidationError(
                        Property.PropertyName, Rule.ErrorMessage));
                    if (Property.OnFirstErrorAction ==
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
