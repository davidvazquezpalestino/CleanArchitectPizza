namespace BlazingPizza.BusinessObjects.Interfaces.GetSpecials;
public interface IGetSpecialsController
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
