namespace BlazingPizza.Presenters;
public static class DependencyContainer
{
    public static IServiceCollection AddPresentersServices(
        this IServiceCollection pServices, string pImagesBaseUrl)
    {
        pServices.AddScoped<IGetSpecialsPresenter>(pRovider =>
        new GetSpecialsPresenter(pImagesBaseUrl));

        return pServices;
    }
}
