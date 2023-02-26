namespace BlazingPizza.WebApi.Endpoints;

internal static class Orders
{
    public static WebApplication UseOrdersEndpoints(
        this WebApplication app)
    {
        app.MapPost("/placeorder",
            async (IPlaceOrderController controller,
                PlaceOrderOrderDto order) =>
            {
                var OrderId = await controller.PlaceOrderAsync(order);
                return Results.Ok(OrderId);
            });

        app.MapGet("/getorders",
            async (IGetOrdersController controller) =>
            {
                return Results.Ok(await controller.GetOrdersAsync());
            });

        app.MapGet("getorder/{id}",
            async (IGetOrderController controller, int id) =>
                Results.Ok(await controller.GetOrderAsync(id)));

        return app;
    }
}
