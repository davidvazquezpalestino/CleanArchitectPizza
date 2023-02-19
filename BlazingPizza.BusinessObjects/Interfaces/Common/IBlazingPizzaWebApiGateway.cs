namespace BlazingPizza.BusinessObjects.Interfaces.Common;
public interface IBlazingPizzaWebApiGateway
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();

    Task<int> PlaceOrderAsync(Order pOrder);
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();
}
