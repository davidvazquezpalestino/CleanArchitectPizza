namespace BlazingPizza.Frontend.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(
        this IServiceCollection services,
        IOptions<EndpointsOptions> endpointsOptions,
        string geocoderApiKey,
        Action<IHttpClientBuilder> httpClientConfigurator = null)
    {
        services.AddModelsServices()
            .AddViewModelsServices()
            .AddBlazingPizzaWebApiGateways(
                 endpointsOptions, httpClientConfigurator)
            .AddValidators()
            .AddToastService()
            .AddSweetAlertService()
            .AddGeolocationService()
            .AddDefaultGeocoderService(geocoderApiKey)
            .AddLeafletServices()
            .AddOrderStatusNotificatorService();


        return services;
    }


}
