using BlazingPizza.BusinessObjects.Interfaces.GetOrders;

namespace BlazingPizza.WebApi.Endpoints;

public static class Orders
{
    public static WebApplication UseOrdersEndpoints(
        this WebApplication pApp)
    {
        pApp.MapPost("/placeorder",
            async (IPlaceOrderController pController,
                PlaceOrderOrderDto pOrder) =>
            {
                var orderId = await pController.PlaceOrderAsync(pOrder);
                return Results.Ok(orderId);
            });

        pApp.MapGet("/getorders",
            async (IGetOrdersController pController) =>
            {
                return Results.Ok(await pController.GetOrdersAsync());
            });

        return pApp;
    }
}
