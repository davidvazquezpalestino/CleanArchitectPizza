using BlazingPizza.BusinessObjects.Entities;

namespace BlazingPizza.WebApi.Endpoints;
public static class Specials
{
    public static WebApplication UseSpecialsEndpoints(this WebApplication pApp)
    {
        pApp.MapGet("/specials",
            async (IGetSpecialsController pController) =>
            {
                IReadOnlyCollection<PizzaSpecial> result = await pController.GetSpecialsAsync();
                return Results.Ok(result);
            });

       // app.MapGet("/hello", () => Results.Ok

        return pApp;
    }
}
