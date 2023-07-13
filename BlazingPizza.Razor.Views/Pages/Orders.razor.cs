namespace BlazingPizza.Razor.Views.Pages;

public partial class Orders
{
    [Inject]
    public IOrdersViewModel ViewModel { get; set; }

    async Task<List<GetOrdersDto>> LoadOrders()
    {
        await ViewModel.GetOrdersAsync();
        return ViewModel.Orders.ToList();
    }
}