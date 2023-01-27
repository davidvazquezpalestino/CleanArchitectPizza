namespace BlazingPizza.Models;
public static class DependencyContainer
{
    public static IServiceCollection AddModelsServices(
        this IServiceCollection pServices)
    {
        pServices.AddScoped<ISpecialsModel, SpecialsModel>();
        pServices.AddScoped<IConfigurePizzaDialogModel,
            ConfigurePizzaDialogModel>();
        pServices.AddScoped<IOrderStateService, OrderStateService>();

        return pServices;
    }

    public static IServiceCollection AddDesktopModelsServices(
        this IServiceCollection pServices)
    {
        pServices.AddScoped<ISpecialsModel, DesktopSpecialsModel>();
        return pServices;
    }
}
