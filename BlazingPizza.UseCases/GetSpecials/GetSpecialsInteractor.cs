namespace BlazingPizza.UseCases.GetSpecials;
internal sealed class GetSpecialsInteractor : IGetSpecialsInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository;

    public GetSpecialsInteractor(IBlazingPizzaQueriesRepository repository)
    {
        Repository = repository;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        var result = await Repository.GetSpecialsAsync();
        return result.OrderByDescending(s => s.BasePrice).ToList();
    }
}
