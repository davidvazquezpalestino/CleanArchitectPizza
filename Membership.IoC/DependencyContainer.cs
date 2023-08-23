namespace Membership.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddCoreMembershipServices(
        this IServiceCollection services)
    {
        services.AddMembershipControllers();
        services.AddUserManagerCoreServices();
        services.AddUserServices();
        services.AddMembershipPresenters();       
        return services;
    }

    public static IServiceCollection AddMembershipServices(
        this IServiceCollection services)
    {
        services.AddCoreMembershipServices();
        services.AddAspNetIdentityServices();
        services.AddRefreshTokenManagerServices();
        return services;
    }
}

