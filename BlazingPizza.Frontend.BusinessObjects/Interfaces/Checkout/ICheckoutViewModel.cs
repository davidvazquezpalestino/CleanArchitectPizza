namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Checkout;
public interface ICheckoutViewModel
{
    Address Address { get; }
    bool IsSubmitting { get; }
    Order Order { get; }
    Task<int> PlaceOrderAsync();

    bool PlaceOrderSuccess { get; }
    Exception PlaceOrderException { get; }
}
