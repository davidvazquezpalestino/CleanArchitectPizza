namespace BlazingPizza.Presenters;
public static class DependencyContainer
{
    public static IServiceCollection AddPresentersServices(
        this IServiceCollection services)
    {
        services.AddScoped<IGetSpecialsPresenter,
            GetSpecialsPresenter>();

        return services;
    }
}
