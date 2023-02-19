namespace BlazingPizza.UseCases.GetOrders;
public class GetOrdersInteractor : IGetOrdersInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetOrdersInteractor(IBlazingPizzaQueriesRepository pRepository)
    {
        Repository = pRepository;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await Repository.GetOrdersAsync();
    }
}
