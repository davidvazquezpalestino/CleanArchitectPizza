namespace Membership.Blazor.UI.HttpMessageHandlers;
internal class BearerTokenHandler : DelegatingHandler, IBearerTokenHandler
{
    readonly IAuthenticationStateProvider AuthenticationStateProvider;

    public BearerTokenHandler(IAuthenticationStateProvider authenticationStateProvider)
    {
        AuthenticationStateProvider = authenticationStateProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        UserTokensDto storedTokens = await AuthenticationStateProvider.GetUserTokensAsync();
        if (storedTokens != default)
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", storedTokens.AccessToken);
        }
        return await base.SendAsync(request, cancellationToken);
    }
}
