﻿using Membership.IoC;

namespace BlazingPizza.Backend.IoC;
public static class DependendencyContainer
{
    public static IServiceCollection AddBlazingPizzaBackendServices(
        this IServiceCollection services)
    {
        services.AddUseCasesServices()
            .AddRepositoriesServices()
            .AddControllersServices()
            .AddPresentersServices()
            .AddValidators()
            .AddHttpExceptionHandlers()
            .AddMembershipServices();

        return services;
    }
}
