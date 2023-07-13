using CustomExceptions;

namespace BlazingPizza.EFCore.Repositories;
internal sealed class BlazingPizzaCommandsRepository : IBlazingPizzaCommandsRepository
{
    readonly IBlazingPizzaCommandsContext Context;

    public BlazingPizzaCommandsRepository(IBlazingPizzaCommandsContext context)
    {
        Context = context;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto order)
    {
        EFEntities.Order Order = order.ToEFOrder();
              
        Context.Orders.Add(Order);
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(ex.Message, ex.InnerException ?? ex);
        }
        return Order.Id;
    }
}
