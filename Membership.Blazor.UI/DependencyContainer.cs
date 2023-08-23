using Membership.Blazor.UI.HttpMessageHandlers;

namespace Membership.Blazor.UI;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipAuthenticationServices(
        this IServiceCollection services)
    {
        services.AddAuthorizationCore();
        services.AddScoped<JWTAuthenticationStateProvider>();

        services.AddScoped<IAuthenticationStateProvider>(provider =>
            provider.GetRequiredService<JWTAuthenticationStateProvider>());

        services.AddScoped<AuthenticationStateProvider,
            JWTAuthenticationStateProvider>(provider =>
            provider.GetRequiredService<JWTAuthenticationStateProvider>());

        services.AddScoped<IBearerTokenHandler, BearerTokenHandler>();

        return services;
    }
}

