namespace Membership.Blazor.WebApiGateway;
internal class UserWebApiGateway : IUserWebApiGateway
{
    readonly UserEndpointsOptions Options;
    readonly HttpClient Client;

    public UserWebApiGateway(IOptions<UserEndpointsOptions> options,
        HttpClient client)
    {
        Options = options.Value;
        Client = client;
        Client.BaseAddress = new Uri(Options.WebApiBaseAddress);
    }

    public async Task<UserTokensDto> LoginAsync(
        UserCredentialsDto userCredentials)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync(
            Options.Login, userCredentials);
        return await response.Content.ReadFromJsonAsync<UserTokensDto>();
    }


    public async Task LogoutAsync(string refreshToken)
    {
        await Client.PostAsJsonAsync(Options.Logout, refreshToken);
    }

    public async Task<UserTokensDto> RefreshTokenAsync(UserTokensDto userTokens)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync(
            Options.RefreshToken, userTokens);
        return await response.Content.ReadFromJsonAsync<UserTokensDto>();
    }

    public async Task RegisterUserAsync(UserForRegistrationDto userData)
    {
        await Client.PostAsJsonAsync(Options.Register, userData);
    }
}
