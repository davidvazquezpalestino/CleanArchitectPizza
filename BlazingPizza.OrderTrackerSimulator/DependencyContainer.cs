namespace BlazingPizza.OrderTrackerSimulator;
public static class DependencyContainer
{
    public static IServiceCollection AddOrderStatusNotificatorService(
        this IServiceCollection services)
    {
        services.AddScoped<IOrderStatusNotificator,
            OrderStatusNotificatorSimulator>();
        return services;
    }
}
