namespace BlazingPizza.BusinessObjects.Interfaces.GetSpecials;
public interface IGetSpecialsInputPort
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
}
