﻿namespace Membership.Controllers;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipControllers(
        this IServiceCollection services)
    {
        services.AddScoped<IRegisterController, RegisterController>();
        services.AddScoped<ILoginController, LoginController>();
        services.AddScoped<IRefreshTokenController, RefreshTokenController>();
        services.AddScoped<ILogoutController, LogoutController>();
        return services;
    }
}

