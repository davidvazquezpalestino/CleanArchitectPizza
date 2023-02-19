namespace BlazingPizza.Razor.Views.Pages;

public partial class Orders
{
    [Inject]
    public IOrdersViewModel ViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await ViewModel.GetOrdersAsync();
    }
}