namespace BlazingPizza.UseCases.GetToppings;
public class GetToppingsInteractor : IGetToppingsInputPort
{
    readonly IBlazingPizzaRepository Repository;

    public GetToppingsInteractor(IBlazingPizzaRepository pRepository)
    {
        Repository = pRepository;
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await Repository.GetToppingsAsync();
    }
}
