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
        var StoredTokens = await AuthenticationStateProvider.GetUserTokensAsync();
        if (StoredTokens != default)
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", StoredTokens.Access_Token);
        }
        return await base.SendAsync(request, cancellationToken);
    }
}
