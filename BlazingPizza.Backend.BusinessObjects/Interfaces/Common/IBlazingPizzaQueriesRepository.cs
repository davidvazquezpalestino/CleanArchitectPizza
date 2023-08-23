namespace BlazingPizza.Backend.BusinessObjects.Interfaces.Common;
public interface IBlazingPizzaQueriesRepository
{
    Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync();
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync(string userId);
    Task<GetOrderDto> GetOrderAsync(int id, string userId);
}
