namespace BlazingPizza.WebApi.Configurations;
public static class ServicesConfiguration
{
    public static WebApplication ConfigureWebApiServices(
        this WebApplicationBuilder pBuilder)
    {
        pBuilder.Services.AddEndpointsApiExplorer();
        pBuilder.Services.AddSwaggerGen();

        pBuilder.Services.AddBlazingPizzaBackendServices(
            pBuilder.Configuration.GetConnectionString("BlazingPizzaDB"),
            pBuilder.Configuration["ImagesBaseUrl"]);

        pBuilder.Services.AddCors(pOptions =>
        {
            pOptions.AddDefaultPolicy(pOlicy =>
            {
                pOlicy.AllowAnyHeader();
                pOlicy.AllowAnyMethod();
                pOlicy.AllowAnyOrigin();
            });
        });
        return pBuilder.Build();
    }
}
