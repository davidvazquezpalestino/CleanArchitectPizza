namespace BlazingPizza.Razor.Views.Pages;
public partial class Checkout
{
    [Inject]
    public ICheckoutViewModel ViewModel { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    async Task PlaceOrder()
    {
        await ViewModel.PlaceOrderAsync();
        NavigationManager.NavigateTo("orders");
    }
}
