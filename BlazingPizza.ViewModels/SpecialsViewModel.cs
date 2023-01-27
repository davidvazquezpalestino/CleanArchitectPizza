namespace BlazingPizza.ViewModels;
public class SpecialsViewModel : ISpecialsViewModel
{
    readonly ISpecialsModel Model;
    public SpecialsViewModel(ISpecialsModel pModel) => Model = pModel;

    public IReadOnlyCollection<PizzaSpecial> Specials
    { get; private set; }

    public async Task GetSpecialsAsync()
    {
        Specials = await Model.GetSpecialsAsync();
    }
}
