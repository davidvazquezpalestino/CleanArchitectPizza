namespace BlazingPizza.Models;
internal sealed class OrdersModel : IOrdersModel
{
    readonly IBlazingPizzaWebApiGateway Gateway;

    public OrdersModel(IBlazingPizzaWebApiGateway gateway)
    {
        Gateway = gateway;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await Gateway.GetOrdersAsync();
        //return await Task.FromResult(new List<GetOrdersDto>());
    }
}
