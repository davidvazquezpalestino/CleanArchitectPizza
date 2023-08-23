namespace BlazingPizza.WebApi.Configurations;

internal static class MiddlewaresConfiguration
{
    public static WebApplication ConfigureWebApiMiddlewares(
        this WebApplication app)
    {
        app.UseHttpExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseSpecialsEndpoints();
        app.UseToppingsEndpoints();
        app.UseOrdersEndpoints();
        app.UseUsersEndpoints();
        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}
