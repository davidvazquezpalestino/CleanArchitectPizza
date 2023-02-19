namespace BlazingPizza.UseCases.GetOrder;
public class GetOrderInteractor : IGetOrderInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetOrderInteractor(IBlazingPizzaQueriesRepository pRepository)
    {
        Repository = pRepository;
    }

    public async Task<GetOrderDto> GetOrderAsync(int pId)
    {
        return await Repository.GetOrderAsync(pId);
    }
}
