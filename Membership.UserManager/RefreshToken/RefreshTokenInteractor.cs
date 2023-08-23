namespace Membership.UserManager.RefreshToken;
internal class RefreshTokenInteractor : IRefreshTokenInputPort
{
    readonly IRefreshTokenManager Manager;
    readonly IRefreshTokenPresenter Presenter;

    public RefreshTokenInteractor(IRefreshTokenManager manager,
        IRefreshTokenPresenter presenter)
    {
        Manager = manager;
        Presenter = presenter;
    }

    public async Task RefreshTokenAsync(UserTokensDto userTokens)
    {
        await Manager.ThrowIfNotCanGetNewTokenAsync(
            userTokens.Refresh_Token, userTokens.Access_Token);
        await Presenter.GenerateTokenAsync(userTokens.Access_Token);
    }
}
