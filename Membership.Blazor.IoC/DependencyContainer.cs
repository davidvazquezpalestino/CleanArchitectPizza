namespace Membership.Blazor.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipBlazorServices(
        this IServiceCollection services,
        Action<UserEndpointsOptions> userEndpoinsOptionsSetter)
    {
        services.AddWebApiGatewayServices(userEndpoinsOptionsSetter);
        services.AddMembershipAuthenticationServices();
        return services;
    }
}

