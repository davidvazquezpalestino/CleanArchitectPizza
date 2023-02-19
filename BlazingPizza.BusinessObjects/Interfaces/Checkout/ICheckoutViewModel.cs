namespace BlazingPizza.BusinessObjects.Interfaces.Checkout;
public interface ICheckoutViewModel
{
    bool IsSubmitting { get; }
    Order Order { get; }
    Task<int> PlaceOrderAsync();
}
