namespace BlazingPizza.BusinessObjects.Interfaces.PlaceOrder;
public interface IPlaceOrderInputPort
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto pOrder);
}
