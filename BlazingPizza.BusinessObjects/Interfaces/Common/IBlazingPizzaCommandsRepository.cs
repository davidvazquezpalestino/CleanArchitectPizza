namespace BlazingPizza.BusinessObjects.Interfaces.Common;
public interface IBlazingPizzaCommandsRepository
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto pOrder);
}
