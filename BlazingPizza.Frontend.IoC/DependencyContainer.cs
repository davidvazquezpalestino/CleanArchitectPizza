namespace BlazingPizza.Frontend.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(
        this IServiceCollection services,
        IOptions<EndpointsOptions> endpointsOptions,
        string geocoderApiKey)
    {
        Action<IHttpClientBuilder> httpClientConfigurator =
            builder =>
            {
                builder.AddHttpMessageHandler(
                    provider => (DelegatingHandler)
                    provider.GetRequiredService<IBearerTokenHandler>());
            };


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
