namespace SpecificationValidation.Abstractions;
internal static class ExpressionHelper
{
    // a => a.Name
    internal static string GetPropertyName<T>(
        Expression<Func<T, object>> propertyExpression)
    {
        MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
        if (memberExpression == null)
        {
            throw new ArgumentException("Invalid body expression.");
        }
        PropertyInfo property = memberExpression.Member as PropertyInfo;
        if (property == null)
        {
            throw new ArgumentException(
                "The expression must contain the property name.");
        }
        return property.Name;
    }
}
