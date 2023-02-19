using BlazingPizza.BusinessObjects.Interfaces.Orders;

namespace BlazingPizza.Models;
public class OrdersModel : IOrdersModel
{
    readonly IBlazingPizzaWebApiGateway Gateway;

    public OrdersModel(IBlazingPizzaWebApiGateway pGateway)
    {
        Gateway = pGateway;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await Gateway.GetOrdersAsync();
    }
}
