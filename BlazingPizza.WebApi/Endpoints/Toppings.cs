namespace BlazingPizza.WebApi.Endpoints;

internal static class Toppings
{
    public static WebApplication UseToppingsEndpoints(
        this WebApplication app)
    {
        app.MapGet("/toppings",
            async (IGetToppingsController controller) =>
            {
                var result = await controller.GetToppingsAsync();
                return Results.Ok(result);
            });
        return app;
    }
}
