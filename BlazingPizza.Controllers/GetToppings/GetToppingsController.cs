namespace BlazingPizza.Controllers.GetToppings;
public class GetToppingsController : IGetToppingsController
{
    readonly IGetToppingsInputPort InputPort;

    public GetToppingsController(IGetToppingsInputPort pInputPort)
    {
        InputPort = pInputPort;
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await InputPort.GetToppingsAsync();
    }
}
