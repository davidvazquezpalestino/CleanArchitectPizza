namespace BlazingPizza.WebApi.Configurations;

public static class MiddlewaresConfiguration
{
    public static WebApplication ConfigureWebApiMiddlewares(
        this WebApplication pApp)
    {
        if (pApp.Environment.IsDevelopment())
        {
            pApp.UseSwagger();
            pApp.UseSwaggerUI();
        }

        pApp.UseHttpsRedirection();
        pApp.UseSpecialsEndpoints();
        pApp.UseToppingsEndpoints();
        pApp.UseOrdersEndpoints();
        pApp.UseCors();

        return pApp;
    }
}
