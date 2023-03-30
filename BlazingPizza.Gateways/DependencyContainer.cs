using HttpMessageHandlers;

namespace BlazingPizza.Gateways;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaWebApiGateways(
        this IServiceCollection services,
        IOptions<EndpointsOptions> endpointsOptions,
        Action<IHttpClientBuilder> httpClientConfigurator = null)
    {
        IHttpClientBuilder Builder =
            services.AddHttpClient<IBlazingPizzaWebApiGateway,
            BlazingPizzaWebApiGateway>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(
                    endpointsOptions.Value.WebApiBaseAddress);
                return new BlazingPizzaWebApiGateway(httpClient, endpointsOptions);
            })
            .AddHttpMessageHandler(() => new ExceptionDelegatingHandler());

        httpClientConfigurator?.Invoke(Builder);

        return services;
    }
}
