﻿namespace BlazingPizza.WebApi.Endpoints;

internal static class Users
{
    public static WebApplication UseUsersEndpoints(
        this WebApplication app)
    {
        app.MapPost("/user/register",
            async (IRegisterController controller,
                UserForRegistrationDto userData) =>
            {
                await controller.RegisterAsync(userData);
                return Results.Ok();
            });


        app.MapPost("/user/login",
            async (ILoginController controller,
            UserCredentialsDto userCredentials,
            HttpContext context) =>
            {
                context.Response.Headers.Add(
                    "Cache-Control", "no-store");
                return Results.Ok(await controller.LoginAsync(userCredentials));
            });

        app.MapPost("/user/refreshtoken",
            async (IRefreshTokenController controller,
            UserTokensDto userTokens,
            HttpContext context) =>
            {
                context.Response.Headers.Add(
                    "Cache-Control", "no-store");
                return Results.Ok(await controller.RefreshTokenAsync(userTokens));
            });

        app.MapPost("/user/logout",
            async (ILogoutController controller, string refreshToken) =>
            {
                await controller.LogoutAsync(refreshToken);
                return Results.NoContent();
            });

        return app;
    }
}
