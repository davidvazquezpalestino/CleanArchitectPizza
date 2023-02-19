namespace BlazingPizza.UseCases.GetSpecials;
public class GetSpecialsInteractor : IGetSpecialsInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetSpecialsInteractor(IBlazingPizzaQueriesRepository pRepository)
    {
        Repository = pRepository;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        var result = await Repository.GetSpecialsAsync();
        return result.OrderByDescending(pS => pS.BasePrice).ToList();
    }
}
