﻿namespace BlazingPizza.EFCore.Repositories;
public static class DependencyContainer
{
    public static IServiceCollection AddRepositoriesServices(
        this IServiceCollection pServices,
        string pConnectionString)
    {
        pServices.AddDbContext<BlazingPizzaContext>(pOptions =>
        pOptions.UseSqlServer(pConnectionString));

        pServices.AddScoped<IBlazingPizzaQueriesRepository, 
            BlazingPizzaQueriesRepository>();

        pServices.AddScoped<IBlazingPizzaCommandsRepository,
            BlazingPizzaCommandsRepository>();

        return pServices;
    }
}
