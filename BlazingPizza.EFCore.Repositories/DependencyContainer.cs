namespace BlazingPizza.EFCore.Repositories;
public static class DependencyContainer
{
    public static IServiceCollection AddRepositoriesServices(
        this IServiceCollection services)
    {
        services.AddDbContext<IBlazingPizzaQueriesContext,
            BlazingPizzaQueriesContext>();

        services.AddDbContext<IBlazingPizzaCommandsContext,
            BlazingPizzaCommandsContext>();

        services.AddScoped<IBlazingPizzaQueriesRepository,
            BlazingPizzaQueriesRepository>();

        services.AddScoped<IBlazingPizzaCommandsRepository,
            BlazingPizzaCommandsRepository>();

        return services;
    }
}
