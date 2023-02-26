namespace BlazingPizza.Controllers.GetOrder;
internal sealed class GetOrderController : IGetOrderController
{
    readonly IGetOrderInputPort InputPort;

    public GetOrderController(IGetOrderInputPort inputPort)
    {
        InputPort = inputPort;
    }

    public async Task<GetOrderDto> GetOrderAsync(int id)
    {
        return await InputPort.GetOrderAsync(id);
    }
}
