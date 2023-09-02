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
            userTokens.RefreshToken, userTokens.AccessToken);
        await Presenter.GenerateTokenAsync(userTokens.AccessToken);
    }
}
