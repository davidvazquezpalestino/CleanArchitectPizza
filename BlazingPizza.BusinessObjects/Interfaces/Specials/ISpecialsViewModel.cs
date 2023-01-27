namespace BlazingPizza.BusinessObjects.Interfaces.Specials;
public interface ISpecialsViewModel
{
    IReadOnlyCollection<PizzaSpecial> Specials { get; }
    Task GetSpecialsAsync();
}
