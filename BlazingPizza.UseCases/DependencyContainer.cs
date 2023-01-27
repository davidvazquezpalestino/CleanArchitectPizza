namespace BlazingPizza.UseCases;
public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(
        this IServiceCollection pServices)
    {
        pServices.AddScoped<IGetSpecialsInputPort, GetSpecialsInteractor>();
        pServices.AddScoped<IGetToppingsInputPort, GetToppingsInteractor>();

        return pServices;
    }
}
