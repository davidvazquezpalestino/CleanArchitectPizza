namespace Membership.UserManager;
public static class DependencyContainer
{
    public static IServiceCollection AddUserManagerCoreServices(
        this IServiceCollection services)
    {
        services.AddScoped<IRegisterInputport, RegisterInteractor>();

        services.AddScoped<ILoginInputPort, LoginInteractor>();

        services.AddScoped<IRefreshTokenInputPort,
            RefreshTokenInteractor>();

        services.AddScoped<ILogoutInputPort, LogoutInteractor>();

        return services;
    }
}

