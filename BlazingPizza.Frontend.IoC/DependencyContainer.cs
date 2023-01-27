namespace BlazingPizza.Frontend.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(
        this IServiceCollection pServices,
        EndpointsOptions pEndpointsOptions,
        Action<IHttpClientBuilder> pHttpClientConfigurator = null)
    {
        pServices.AddModelsServices()
            .AddViewModelsServices()
            .AddBlazingPizzaWebApiGateways(pEndpointsOptions, pHttpClientConfigurator);

        return pServices;
    }

    public static IServiceCollection AddBlazingPizzaDesktopServices(
        this IServiceCollection pServices)
    {
        pServices.AddDesktopModelsServices()
            .AddViewModelsServices();

        return pServices;
    }
}
