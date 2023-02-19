namespace BlazingPizza.Controllers.GetOrder;
public class GetOrderController : IGetOrderController
{
    readonly IGetOrderInputPort InputPort;

    public GetOrderController(IGetOrderInputPort pInputPort)
    {
        InputPort = pInputPort;
    }

    public async Task<GetOrderDto> GetOrderAsync(int pId)
    {
        return await InputPort.GetOrderAsync(pId);
    }
}
