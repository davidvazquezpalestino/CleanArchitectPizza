namespace BlazingPizza.WebApi.Endpoints;
internal static class Specials
{
    public static WebApplication UseSpecialsEndpoints(this WebApplication app)
    {
        app.MapGet("/specials",
            async (IGetSpecialsController controller) =>
            {
                var result = await controller.GetSpecialsAsync();
                return Results.Ok(result);
            });

       // app.MapGet("/hello", () => Results.Ok

        return app;
    }
}
