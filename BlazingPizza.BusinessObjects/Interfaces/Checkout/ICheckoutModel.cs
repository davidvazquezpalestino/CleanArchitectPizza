namespace BlazingPizza.BusinessObjects.Interfaces.Checkout;
public interface ICheckoutModel
{
    Task<int> PlaceOrderAsync(Order pOrder);
}
