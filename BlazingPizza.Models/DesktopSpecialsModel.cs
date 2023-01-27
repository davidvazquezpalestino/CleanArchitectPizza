namespace BlazingPizza.Models;
public class DesktopSpecialsModel : ISpecialsModel
{
    readonly IGetSpecialsController Controller;

    public DesktopSpecialsModel(IGetSpecialsController pController)
    {
        Controller = pController;
    }

    public Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        return Controller.GetSpecialsAsync();
    }
}
