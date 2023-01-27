namespace BlazingPizza.Controllers;
public static class DependencyContainer
{
    public static IServiceCollection AddControllersServices(
        this IServiceCollection pServices)
    {
        pServices.AddScoped<IGetSpecialsController, GetSpecialsController>();
        pServices.AddScoped<IGetToppingsController, GetToppingsController>();
        return pServices;
    }
}
