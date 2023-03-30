namespace BlazingPizza.Shared.Validators;
public static class DependencyContainer
{
    public static IServiceCollection AddValidators(
        this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            Assembly.GetExecutingAssembly());

        return services;
    }
}
