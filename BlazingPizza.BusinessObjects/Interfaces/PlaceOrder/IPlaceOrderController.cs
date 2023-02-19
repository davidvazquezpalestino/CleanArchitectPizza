namespace BlazingPizza.BusinessObjects.Interfaces.PlaceOrder;
public interface IPlaceOrderController
{
    Task<int> PlaceOrderAsync(PlaceOrderOrderDto pOrder);
}
