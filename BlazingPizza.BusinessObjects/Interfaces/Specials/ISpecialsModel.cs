namespace BlazingPizza.BusinessObjects.Interfaces.Specials;
public interface ISpecialsModel
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
