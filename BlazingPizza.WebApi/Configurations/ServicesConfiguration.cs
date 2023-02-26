namespace BlazingPizza.WebApi.Configurations;
internal static class ServicesConfiguration
{
    public static WebApplication ConfigureWebApiServices(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<SpecialsOptions>(
            builder.Configuration.GetSection(
                SpecialsOptions.SectionKey));

        builder.Services.Configure<ConnectionStringsOptions>(
            builder.Configuration.GetSection(
                ConnectionStringsOptions.SectionKey));

        builder.Services.AddBlazingPizzaBackendServices();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
        return builder.Build();
    }
}
