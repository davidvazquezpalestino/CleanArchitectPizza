namespace Membership.Controllers;
internal class RefreshTokenController : IRefreshTokenController
{
    readonly IRefreshTokenInputPort InputPort;
    readonly IRefreshTokenPresenter Presenter;

    public RefreshTokenController(IRefreshTokenInputPort inputPort, 
        IRefreshTokenPresenter presenter)
    {
        InputPort = inputPort;
        Presenter = presenter;
    }

    public async Task<UserTokensDto> RefreshTokenAsync(UserTokensDto userTokens)
    {
        await InputPort.RefreshTokenAsync(userTokens);
        return Presenter.UserTokens;
    }    
}
