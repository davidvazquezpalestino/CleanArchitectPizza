namespace Membership.Blazor.WebApiGateway;
public static class DependencyContainer
{
    public static IServiceCollection AddWebApiGatewayServices(
        this IServiceCollection services,
        Action<UserEndpointsOptions> userEndpoinsOptionsSetter)
    {
        services.AddOptions<UserEndpointsOptions>()
            .Configure(userEndpoinsOptionsSetter);

        services.AddHttpClient<IUserWebApiGateway, UserWebApiGateway>()
            .AddHttpMessageHandler(() => new ExceptionDelegatingHandler());

        return services;
    }
}

