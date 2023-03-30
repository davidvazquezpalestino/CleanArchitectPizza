namespace SpecificationValidation.Abstractions;
public class PropertyRule<T>
{
    public PropertyRule<T> AddRule(Func<T, bool> predicate,
        string errorMessage)
    {
        Rules.Add(new Rule<T>(predicate, errorMessage));
        return this;
    }
    public PropertyRule<T> ContinueOnError()
    {
        OnFirstErrorAction = OnFirstErrorAction.ContinueValidation;
        return this;
    }
    internal string PropertyName { get; }
    internal List<Rule<T>> Rules { get; }
    internal OnFirstErrorAction OnFirstErrorAction { get; private set; }

    internal PropertyRule(string propertyName)
    {
        PropertyName = propertyName;
        Rules = new();
        OnFirstErrorAction = OnFirstErrorAction.StopValidation;
    }
}
