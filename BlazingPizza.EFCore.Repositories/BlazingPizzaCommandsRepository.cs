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
        await Context.SaveChangesAsync();
        return Order.Id;
    }
}
