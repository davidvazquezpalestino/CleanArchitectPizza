namespace BlazingPizza.UseCases.GetToppings;
public class GetToppingsInteractor : IGetToppingsInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetToppingsInteractor(IBlazingPizzaQueriesRepository pRepository)
    {
        Repository = pRepository;
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await Repository.GetToppingsAsync();
    }
}
