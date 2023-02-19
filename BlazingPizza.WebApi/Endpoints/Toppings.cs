namespace BlazingPizza.WebApi.Endpoints;

public static class Toppings
{
    public static WebApplication UseToppingsEndpoints(
        this WebApplication pApp)
    {
        pApp.MapGet("/toppings",
            async (IGetToppingsController pController) =>
            {
                var result = await pController.GetToppingsAsync();
                return Results.Ok(result);
            });
        return pApp;
    }
}
