namespace BlazingPizza.Controllers.GetOrders;
public class GetOrdersController : IGetOrdersController
{
    readonly IGetOrdersInputPort InputPort;

    public GetOrdersController(IGetOrdersInputPort pInputPort)
    {
        InputPort = pInputPort;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await InputPort.GetOrdersAsync();
    }
}
