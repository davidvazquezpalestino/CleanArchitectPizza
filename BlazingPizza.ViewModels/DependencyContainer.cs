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

        return pServices;
    }
}
