namespace BlazingPizza.Frontend.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(
        this IServiceCollection services,
        IOptions<EndpointsOptions> endpointsOptions,
        Action<IHttpClientBuilder> httpClientConfigurator = null)
    {
        services.AddModelsServices()
            .AddViewModelsServices()
            .AddBlazingPizzaWebApiGateways(
                 endpointsOptions, httpClientConfigurator);

        return services;
    }

    //public static IServiceCollection AddBlazingPizzaDesktopServices(
    //    this IServiceCollection services)
    //{
    //    services.AddDesktopModelsServices()
    //        .AddViewModelsServices();

    //    return services;
    //}
}
