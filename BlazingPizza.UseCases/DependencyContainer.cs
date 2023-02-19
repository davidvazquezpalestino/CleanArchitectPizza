namespace BlazingPizza.UseCases;
public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(
        this IServiceCollection pServices)
    {
        pServices.AddScoped<IGetSpecialsInputPort, GetSpecialsInteractor>();
        pServices.AddScoped<IGetToppingsInputPort, GetToppingsInteractor>();
        pServices.AddScoped<IPlaceOrderInputPort, PlaceOrderInteractor>();
        pServices.AddScoped<IGetOrdersInputPort, GetOrdersInteractor>();
        pServices.AddScoped<IGetOrderInputPort, GetOrderInteractor>();

        return pServices;
    }
}
