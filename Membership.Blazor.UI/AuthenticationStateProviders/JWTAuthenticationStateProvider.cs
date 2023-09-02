namespace Membership.Blazor.UI.AuthenticationStateProviders;
internal class JWTAuthenticationStateProvider : AuthenticationStateProvider, IAuthenticationStateProvider
{
    const string SessionKey = "ast";
    readonly IJSRuntime JsRuntime;
    readonly IUserWebApiGateway UserWebApiGateway;
    public JWTAuthenticationStateProvider(IJSRuntime jsRuntime, 
        IUserWebApiGateway userWebApiGateway)
    {
        JsRuntime = jsRuntime;
        UserWebApiGateway = userWebApiGateway;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsIdentity identity = new ClaimsIdentity();

        UserTokensDto storedTokens = await GetUserTokensAsync();

        if (storedTokens != default)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadJwtToken(storedTokens.AccessToken);
            identity = new ClaimsIdentity(token.Claims, nameof(JWTAuthenticationStateProvider));
        }

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public async Task<UserTokensDto> GetUserTokensAsync()
    {
        string state = await JsRuntime.InvokeAsync<string>("sessionStorage.getItem", SessionKey);

        UserTokensDto storedTokens = default;
        if(state != null)
        {
            storedTokens = JsonSerializer.Deserialize<UserTokensDto>(state);
            /* Verificar el token de acceso */

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadJwtToken(storedTokens.AccessToken);
            if(token.ValidTo <= DateTime.UtcNow)
            {
                try
                {
                    UserTokensDto newTokens = await UserWebApiGateway.RefreshTokenAsync(storedTokens);
                    await LoginAsync(newTokens);
                    storedTokens = newTokens;
                    Console.WriteLine();
                    Console.WriteLine("***** Access token actualizado.");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    storedTokens = default;
                    Console.WriteLine(ex.Message);
                    await LogoutAsync();
                }
            }

            /* Verificar el token de acceso */
        }
        return storedTokens;       
    }

    public async Task LoginAsync(UserTokensDto userTokensDto)
    {
        string state = JsonSerializer.Serialize(userTokensDto);
        await JsRuntime.InvokeVoidAsync("sessionStorage.setItem", SessionKey, state);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await JsRuntime.InvokeVoidAsync("sessionStorage.removeItem", SessionKey);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
