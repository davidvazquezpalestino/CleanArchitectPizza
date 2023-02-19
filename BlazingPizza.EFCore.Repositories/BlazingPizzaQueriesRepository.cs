using BlazingPizza.BusinessObjects.Aggregates;

namespace BlazingPizza.EFCore.Repositories;
public class BlazingPizzaQueriesRepository : IBlazingPizzaQueriesRepository
{
    readonly BlazingPizzaContext Context;

    public BlazingPizzaQueriesRepository(BlazingPizzaContext pContext)
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
    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync() =>
        (await Context.Orders
            .Include(pO => pO.DeliveryAddress)
            .Include(pO => pO.DeliveryLocation)
            .Include(pO => pO.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .OrderByDescending(pO => pO.CreatedTime)
            .ToListAsync())
            .Select(pO => GetOrdersDtoFake(pO.ToOrder())).ToList();

   

    public async Task<GetOrderDto> GetOrderAsync(int pId)
    {
        var order = await Context.Orders
            .Where(pO => pO.Id == pId)
            .Include(pO => pO.Pizzas).ThenInclude(p => p.PizzaSpecial)
            .Include(pO => pO.Pizzas).ThenInclude(p => p.Toppings)
                .ThenInclude(pT => pT.Topping)
            .FirstOrDefaultAsync();

        return order == null ? new GetOrderDto() :
            GetOrdersDtoFake(order.ToOrder());

    }





    #region Código para simular el estado de una orden
    void GetStatus(BusinessObjects.Aggregates.Order pOrder, 
        out string pStatusText, out bool pISDelivered)
    {
        const string preparing = "Preparando";
        const string outForDelivery = "En camino";
        const string delivered = "Entregado";

        TimeSpan preparationDurationTime = 
            TimeSpan.FromSeconds(10);

        TimeSpan deliveryDurationTime =
            TimeSpan.FromMinutes(1);

        DateTime dispatchTime = 
            pOrder.CreatedTime.Add(preparationDurationTime);

        if (DateTime.Now < dispatchTime)
        {
            pStatusText = preparing;
        }
        else if (DateTime.Now < dispatchTime + deliveryDurationTime)
        {
            pStatusText = outForDelivery;
        }
        else
        {
            pStatusText = delivered;
        }

        pISDelivered = pStatusText == delivered;
    }


    GetOrdersDto GetOrdersDtoFake(BusinessObjects.Aggregates.Order pOrder)
    {
        string statusText;
        bool isDelivered;
        GetStatus(pOrder, out statusText, out isDelivered);
        return new GetOrdersDto(
            pOrder.Id, pOrder.CreatedTime, pOrder.UserId,
            pOrder.Pizzas.Count, pOrder.GetTotalPrice(), 
            statusText, isDelivered);
    }

    GetOrderDto GetOrderDtoFake(BusinessObjects.Aggregates.Order pOrder)
    {
        string statusText;
        bool isDelivered;
        GetStatus(pOrder, out statusText, out isDelivered);
        return new GetOrderDto
        {
            Id= pOrder.Id,
             CreatedTime= pOrder.CreatedTime,
              Pizzas = pOrder.Pizzas.Select() ???? NECESITAMOS UN MAPPER
        }
            pOrder.Id, pOrder.CreatedTime, pOrder.UserId,
            pOrder.Pizzas.Count, pOrder.GetTotalPrice(),
            statusText, isDelivered);
    }



    #endregion
}
