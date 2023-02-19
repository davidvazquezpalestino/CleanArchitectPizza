namespace BlazingPizza.EFCore.Repositories;
public class BlazingPizzaCommandsRepository : IBlazingPizzaCommandsRepository
{
    readonly BlazingPizzaContext Context;

    public BlazingPizzaCommandsRepository(BlazingPizzaContext pContext)
    {
        Context = pContext;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto pOrder)
    {
        EFEntities.Order order = pOrder.ToEfOrder();

        Context.Orders.Add(order);
        await Context.SaveChangesAsync();
        return order.Id;
    }
}
