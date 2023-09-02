namespace BlazingPizza.EFCore.Repositories;
internal sealed class BlazingPizzaQueriesRepository : IBlazingPizzaQueriesRepository
{
    readonly IBlazingPizzaQueriesContext Context;

    public BlazingPizzaQueriesRepository(IBlazingPizzaQueriesContext context)
    {
        Context = context;
    }

    public async Task<IReadOnlyCollection<SharedEntities.PizzaSpecial>>
        GetSpecialsAsync()
    {
        return await Context.Specials
            .Select(s => s.ToPizzaSpecial())
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<
        SharedEntities.Topping>> GetToppingsAsync()
    {
        return await Context.Toppings
            .Select(t => t.ToTopping())
            .ToListAsync();
    }
    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync(string userId) =>
        (await Context.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                .ThenInclude(t => t.Topping)
            .OrderByDescending(o => o.CreatedTime)
            .ToListAsync())
            .Select(o => GetOrdersDtoFake(o.ToOrder())).ToList();

   

    public async Task<GetOrderDto> GetOrderAsync(int id, string userId)
    {
        EFEntities.Order order = await Context.Orders
            .Where(o => o.UserId == userId)
            .Where(o => o.Id == id)
            .Include(o => o.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                .ThenInclude(t => t.Topping)
            .FirstOrDefaultAsync();

        return order == null ? new GetOrderDto() :
            GetOrderDtoFake(order.ToOrder());
    }


    #region Código para simular el estado de una orden
    void GetStatus(SharedAggregates.Order order, 
        out OrderStatus status, out bool isDelivered)
    {
        TimeSpan preparationDurationTime = 
            TimeSpan.FromSeconds(10);

        TimeSpan deliveryDurationTime =
            TimeSpan.FromMinutes(1.5);

        DateTime dispatchTime = 
            order.CreatedTime.Add(preparationDurationTime);

        if (DateTime.Now < dispatchTime)
        {
            status = OrderStatus.Preparing;
        }
        else if (DateTime.Now < dispatchTime + deliveryDurationTime)
        {
            status = OrderStatus.OutForDelivery;
        }
        else
        {
            status = OrderStatus.Delivered;
        }

        isDelivered = status == OrderStatus.Delivered;
    }


    GetOrdersDto GetOrdersDtoFake(SharedAggregates.Order order)
    {
        OrderStatus status;
        bool isDelivered;
        GetStatus(order, out status, out isDelivered);
        return new GetOrdersDto(
            order.Id, order.CreatedTime, order.UserId,
            order.Pizzas.Count, order.GetTotalPrice(), 
            status, isDelivered);
    }

    GetOrderDto GetOrderDtoFake(SharedAggregates.Order order)
    {
        OrderStatus status;
        bool isDelivered;
        GetStatus(order, out status, out isDelivered);        
        return new GetOrderDto
        {
            Id = order.Id,
            CreatedTime = order.CreatedTime,
            Pizzas = order.Pizzas.Select(p => (PizzaDto)p).ToList(),
            Status = status,
            IsDelivered = isDelivered,
            DeliveryLocation = order.DeliveryLocation
        };
    }



    #endregion
}
