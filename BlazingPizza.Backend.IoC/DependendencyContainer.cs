namespace BlazingPizza.Backend.IoC;
public static class DependendencyContainer
{
    public static IServiceCollection AddBlazingPizzaBackendServices(
        this IServiceCollection pServices, string pConnectionString,
        string pImagesBaseUrlName)
    {
        pServices.AddUseCasesServices()
            .AddRepositoriesServices(pConnectionString)
            .AddControllersServices()
            .AddPresentersServices(pImagesBaseUrlName);

        return pServices;
    }
}
