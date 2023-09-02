using CustomExceptions;

namespace BlazingPizza.EFCore.Repositories;
internal sealed class BlazingPizzaCommandsRepository : IBlazingPizzaCommandsRepository
{
    readonly IBlazingPizzaCommandsContext Context;

    public BlazingPizzaCommandsRepository(IBlazingPizzaCommandsContext context)
    {
        Context = context;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto placeOrder)
    {
        EFEntities.Order order = placeOrder.ToEfOrder();
              
        Context.Orders.Add(order);
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new PersistenceException(ex.Message, ex.InnerException ?? ex);
        }
        return order.Id;
    }
}
