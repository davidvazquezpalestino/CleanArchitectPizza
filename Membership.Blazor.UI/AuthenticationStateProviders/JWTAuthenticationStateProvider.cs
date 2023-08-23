namespace Membership.Blazor.UI.AuthenticationStateProviders;
internal class JWTAuthenticationStateProvider : AuthenticationStateProvider,
    IAuthenticationStateProvider
{
    const string SessionKey = "ast";
    readonly IJSRuntime JSRuntime;
    readonly IUserWebApiGateway UserWebApiGateway;
    public JWTAuthenticationStateProvider(IJSRuntime jsRuntime, 
        IUserWebApiGateway userWebApiGateway)
    {
        JSRuntime = jsRuntime;
        UserWebApiGateway = userWebApiGateway;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsIdentity Identity = new ClaimsIdentity();

        var StoredTokens = await GetUserTokensAsync();

        if (StoredTokens != default)
        {
            var Handler = new JwtSecurityTokenHandler();
            var Token = Handler.ReadJwtToken(StoredTokens.Access_Token);
            Identity = new ClaimsIdentity(Token.Claims,
                nameof(JWTAuthenticationStateProvider));
        }

        return new AuthenticationState(
            new ClaimsPrincipal(Identity));
    }

    public async Task<UserTokensDto> GetUserTokensAsync()
    {
        string State = await JSRuntime.InvokeAsync<string>(
            "sessionStorage.getItem", SessionKey);

        UserTokensDto StoredTokens = default;
        if(State != null)
        {
            StoredTokens = JsonSerializer.Deserialize<UserTokensDto>(State);
            /* Verificar el token de acceso */

            var Handler = new JwtSecurityTokenHandler();
            var Token = Handler.ReadJwtToken(StoredTokens.Access_Token);
            if(Token.ValidTo <= DateTime.UtcNow)
            {
                try
                {
                    var NewTokens = await UserWebApiGateway.RefreshTokenAsync(
                        StoredTokens);
                    await LoginAsync(NewTokens);
                    StoredTokens = NewTokens;
                    Console.WriteLine();
                    Console.WriteLine("***** Access token actualizado.");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    StoredTokens = default;
                    Console.WriteLine(ex.Message);
                    await LogoutAsync();
                }
            }

            /* Verificar el token de acceso */
        }
        return StoredTokens;       
    }

    public async Task LoginAsync(UserTokensDto userTokensDto)
    {
        string State = JsonSerializer.Serialize(userTokensDto);
        await JSRuntime.InvokeVoidAsync(
            "sessionStorage.setItem", SessionKey, State);

        NotifyAuthenticationStateChanged(
            GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await JSRuntime.InvokeVoidAsync(
            "sessionStorage.removeItem", SessionKey);

        NotifyAuthenticationStateChanged(
            GetAuthenticationStateAsync());
    }
}
