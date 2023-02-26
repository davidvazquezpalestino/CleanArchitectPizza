namespace BlazingPizza.UseCases.GetOrder;
internal sealed class GetOrderInteractor : IGetOrderInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetOrderInteractor(IBlazingPizzaQueriesRepository repository)
    {
        Repository = repository;
    }

    public async Task<GetOrderDto> GetOrderAsync(int id)
    {
        return await Repository.GetOrderAsync(id);
    }
}
