namespace BlazingPizza.BusinessObjects.Interfaces.Common;
public interface IBlazingPizzaRepository
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
