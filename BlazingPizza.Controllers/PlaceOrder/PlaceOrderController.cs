namespace BlazingPizza.Controllers.PlaceOrder;
public class PlaceOrderController : IPlaceOrderController
{
    readonly IPlaceOrderInputPort InputPort;

    public PlaceOrderController(IPlaceOrderInputPort pInputPort)
    {
        InputPort = pInputPort;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto pOrder)
    {
        return await InputPort.PlaceOrderAsync(pOrder);
    }
}
