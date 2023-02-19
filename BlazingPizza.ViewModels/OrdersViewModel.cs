using BlazingPizza.BusinessObjects.Interfaces.Orders;

namespace BlazingPizza.ViewModels;
public class OrdersViewModel : IOrdersViewModel
{
    readonly IOrdersModel Model;

    public OrdersViewModel(IOrdersModel pModel)
    {
        Model = pModel;
    }

    public IReadOnlyCollection<GetOrdersDto> Orders
    { get; private set; }

    public async Task GetOrdersAsync()
    {
        Orders = await Model.GetOrdersAsync();
    }
}
