namespace BlazingPizza.ViewModels;
public class CheckoutViewModel : ICheckoutViewModel
{
    readonly ICheckoutModel Model;
    readonly IOrderStateService OrderStateService;

    public CheckoutViewModel(ICheckoutModel pModel,
        IOrderStateService pOrderStateService)
    {
        Model = pModel;
        OrderStateService = pOrderStateService;
    }

    public bool IsSubmitting { get; private set; }

    public Order Order => OrderStateService.Order;

    public async Task<int> PlaceOrderAsync()
    {
        IsSubmitting = true;
        int orderId = await Model.PlaceOrderAsync(Order);
        OrderStateService.ResetOrder();
        IsSubmitting = false;
        return orderId;
    }
}
