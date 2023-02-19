using BlazingPizza.BusinessObjects.Interfaces.Orders;

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

        pServices.AddScoped<ICheckoutModel, CheckoutModel>();
        pServices.AddScoped<IOrdersModel, OrdersModel>();

        return pServices;
    }

    public static IServiceCollection AddDesktopModelsServices(
        this IServiceCollection pServices)
    {
        pServices.AddScoped<ISpecialsModel, DesktopSpecialsModel>();
        return pServices;
    }
}
