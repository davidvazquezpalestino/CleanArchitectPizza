namespace BlazingPizza.UseCases.GetSpecials;
public class GetSpecialsInteractor : IGetSpecialsInputPort
{
    readonly IBlazingPizzaRepository Repository;

    public GetSpecialsInteractor(IBlazingPizzaRepository pRepository)
    {
        Repository = pRepository;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        IReadOnlyCollection<PizzaSpecial>? result = await Repository.GetSpecialsAsync();
        return result.OrderByDescending(pS => pS.BasePrice).ToList();
    }
}
