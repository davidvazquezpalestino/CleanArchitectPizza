namespace BlazingPizza.EFCore.Repositories;
public class BlazingPizzaRepository : IBlazingPizzaRepository
{
    readonly BlazingPizzaContext Context;

    public BlazingPizzaRepository(BlazingPizzaContext pContext)
    {
        Context = pContext;
        Context.ChangeTracker.QueryTrackingBehavior = 
            QueryTrackingBehavior.NoTracking;
    }

    public async Task<IReadOnlyCollection<BusinessObjects.Entities.PizzaSpecial>>
        GetSpecialsAsync()
    {
        return await Context.Specials
            .Select(pS => pS.ToPizzaSpecial())
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<
        BusinessObjects.Entities.Topping>> GetToppingsAsync()
    {
        return await Context.Toppings
            .Select(pT => pT.ToTopping())
            .ToListAsync();
    }
}
