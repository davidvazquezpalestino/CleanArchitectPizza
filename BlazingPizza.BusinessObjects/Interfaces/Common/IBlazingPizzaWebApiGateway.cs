namespace BlazingPizza.BusinessObjects.Interfaces.Common;
public interface IBlazingPizzaWebApiGateway
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
