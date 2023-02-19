using BlazingPizza.BusinessObjects.Interfaces.Orders;

namespace BlazingPizza.ViewModels;
public static class DependencyContainer
{
    public static IServiceCollection AddViewModelsServices(
        this IServiceCollection pServices)
    {
        pServices.AddScoped<ISpecialsViewModel, SpecialsViewModel>();
        pServices.AddScoped<IIndexViewModel, IndexViewModel>();
        pServices.AddScoped<IConfigurePizzaDialogViewModel,
            ConfigurePizzaDialogViewModel>();

        pServices.AddScoped<ICheckoutViewModel, CheckoutViewModel>();
        pServices.AddScoped<IOrdersViewModel, OrdersViewModel>();

        return pServices;
    }
}
