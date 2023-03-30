namespace SpecificationValidation.Abstractions;
internal class Rule<T> 
{
    public Func<T, bool> Predicate { get; }
    public string ErrorMessage { get; }

    public Rule(Func<T, bool> predicate, string errorMessage)
    {
        Predicate = predicate;
        ErrorMessage = errorMessage;
    }
}
