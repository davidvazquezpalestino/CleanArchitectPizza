namespace BlazingPizza.ViewModels;
internal sealed class CheckoutViewModel : ICheckoutViewModel
{
    readonly ICheckoutModel Model;
    readonly IOrderStateService OrderStateService;

    public CheckoutViewModel(ICheckoutModel model,
        IOrderStateService orderStateService)
    {
        Model = model;
        OrderStateService = orderStateService;
    }

    public bool IsSubmitting { get; private set; }

    public Order Order => OrderStateService.Order;

    public Address Address { get; private set; } = new Address();

    public Exception PlaceOrderException { get; private set; }
    public bool PlaceOrderSuccess =>
        PlaceOrderException == null;

    public async Task<int> PlaceOrderAsync()
    {
        int OrderId = 0;

        IsSubmitting = true;
        Order.SetDeliveryAddress(Address);

        try
        {
            OrderId = await Model.PlaceOrderAsync(Order);
            OrderStateService.ResetOrder();
            Address = new Address();
        }
        catch (Exception ex)
        {
            PlaceOrderException = ex;
        }

        IsSubmitting = false;

        return OrderId;
    }


}
