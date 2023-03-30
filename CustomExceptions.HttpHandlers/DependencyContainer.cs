namespace CustomExceptions.HttpHandlers;
using Microsoft.AspNetCore.Builder;
public static class DependencyContainer
{
    public static IServiceCollection AddHttpExceptionHandlers(
        this IServiceCollection services,
        Assembly exceptionHandlersAssembly)
    {
        services.AddSingleton<IHttpExceptionHandlerHub>(provider =>
            new HttpExceptionHandlerHub(exceptionHandlersAssembly));

        return services;
    }

    public static IServiceCollection AddHttpExceptionHandlers(
    this IServiceCollection services) =>
        AddHttpExceptionHandlers(services, Assembly.GetExecutingAssembly());

    public static IApplicationBuilder UseHttpExceptionHandlerMiddleware(
        this IApplicationBuilder app,
        IHostEnvironment environment,
        IHttpExceptionHandlerHub hub)
    {
        app.Use((context, next) =>
           HttpExceptionHandlerMiddleware.WriteResponse(context,
           environment.IsDevelopment(), hub));
        return app;
    }

    public static IApplicationBuilder UseHttpExceptionHandler(
    this IApplicationBuilder app)
    {
        app.UseExceptionHandler(builder =>
            builder.UseHttpExceptionHandlerMiddleware(
                app.ApplicationServices.GetRequiredService<IHostEnvironment>(),
                app.ApplicationServices.GetRequiredService<IHttpExceptionHandlerHub>()));
        return app;
    }
}
