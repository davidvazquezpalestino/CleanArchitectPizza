namespace SpecificationValidation.Abstractions;
internal static class ExpressionHelper
{
    // a => a.Name
    internal static string GetPropertyName<T>(
        Expression<Func<T, object>> propertyExpression)
    {
        var MemberExpression = propertyExpression.Body as MemberExpression;
        if (MemberExpression == null)
        {
            throw new ArgumentException("Invalid body expression.");
        }
        var Property = MemberExpression.Member as PropertyInfo;
        if (Property == null)
        {
            throw new ArgumentException(
                "The expression must contain the property name.");
        }
        return Property.Name;
    }
}
