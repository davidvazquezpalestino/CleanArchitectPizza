namespace BlazingPizza.UseCases.GetOrders;
internal sealed class GetOrdersInteractor : IGetOrdersInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetOrdersInteractor(IBlazingPizzaQueriesRepository repository)
    {
        Repository = repository;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await Repository.GetOrdersAsync();
    }
}
