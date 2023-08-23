using Membership.Entities.Interfaces;

namespace Membership.UserManager.AspNetIdentity;
public static class DependencyContainer
{
    public static IServiceCollection AddAspNetIdentityServices(
        this IServiceCollection services)
    {
        services.AddDbContext<UserManagerContext>();

        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<UserManagerContext>();

        services.AddScoped<IUserManagerService, UserManagerService>();

        return services;
    }
}


