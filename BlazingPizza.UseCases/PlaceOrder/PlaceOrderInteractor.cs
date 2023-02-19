namespace BlazingPizza.UseCases.PlaceOrder;
public class PlaceOrderInteractor : IPlaceOrderInputPort
{
    readonly IBlazingPizzaCommandsRepository Repository;

    public PlaceOrderInteractor(IBlazingPizzaCommandsRepository pRepository)
    {
        Repository = pRepository;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto pOrder)
    {
        return await Repository.PlaceOrderAsync(pOrder);
    }
}
