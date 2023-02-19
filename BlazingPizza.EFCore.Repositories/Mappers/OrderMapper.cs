namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class OrderMapper
{
    internal static EFEntities.Order ToEfOrder(
        this BusinessObjects.Dtos.PlaceOrderOrderDto pOrder) =>
        new EFEntities.Order
        {
            CreatedTime = DateTime.Now,
            UserId = pOrder.UserId,
            DeliveryAddress = pOrder.DeliveryAddress.ToEfAddress(),
            DeliveryLocation = pOrder.DeliveryLocation.ToEfLatLong(),
            Pizzas = pOrder.Pizzas.Select(p => p.ToEfPizza()).ToList()
        };

    internal static BusinessObjects.Aggregates.Order ToOrder(
        this EFEntities.Order pOrder) =>
        BusinessObjects.Aggregates.Order.Create(
            pOrder.Id, pOrder.CreatedTime, pOrder.UserId)
            .SetDeliveryAddress(pOrder.DeliveryAddress.ToAddress())
            .SetDeliveryLocation(pOrder.DeliveryLocation.ToLatLong())
            .AddPizzas(pOrder.Pizzas?.Select(p => p.ToPizza()));
    
}
