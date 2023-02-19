namespace BlazingPizza.Controllers;
public static class DependencyContainer
{
    public static IServiceCollection AddControllersServices(
        this IServiceCollection pServices)
    {
        pServices.AddScoped<IGetSpecialsController, GetSpecialsController>();
        pServices.AddScoped<IGetToppingsController, GetToppingsController>();
        pServices.AddScoped<IPlaceOrderController, PlaceOrderController>();
        pServices.AddScoped<IGetOrdersController, GetOrdersController>();
        pServices.AddScoped<IGetOrderController, GetOrderController>();
        return pServices;
    }
}
