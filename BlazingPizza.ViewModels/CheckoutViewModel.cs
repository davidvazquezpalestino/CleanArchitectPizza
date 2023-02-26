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

    public async Task<int> PlaceOrderAsync()
    {
        IsSubmitting = true;
        int OrderId = await Model.PlaceOrderAsync(Order);
        OrderStateService.ResetOrder();
        IsSubmitting = false;
        return OrderId;
    }
}
