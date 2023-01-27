namespace BlazingPizza.Gateways;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaWebApiGateways(
        this IServiceCollection pServices,
        EndpointsOptions pEndpointsOptions,
        Action<IHttpClientBuilder> pHttpClientConfigurator = null)
    {
        IHttpClientBuilder builder =
            pServices.AddHttpClient<IBlazingPizzaWebApiGateway,
            BlazingPizzaWebApiGateway>(pHttpClient =>
            {
                pHttpClient.BaseAddress = new Uri(pEndpointsOptions.WebApiBaseAddress);
                return new BlazingPizzaWebApiGateway(pHttpClient, pEndpointsOptions);
            });

        pHttpClientConfigurator?.Invoke(builder);

        return pServices;
    }
}
