namespace Membership.Presenters;
internal class LoginPresenter : ILoginPresenter
{
    readonly JwtConfigurationOptions Options;
    readonly IRefreshTokenManager RefreshTokenManager;

    public LoginPresenter(IOptions<JwtConfigurationOptions> options,
        IRefreshTokenManager refreshTokenManager)
    {
        Options = options.Value;
        RefreshTokenManager = refreshTokenManager;
    }

    public UserTokensDto UserTokens {get; private set;}

    public async Task HandleUserDataAsync(UserDto userData)
    {
        List<Claim> claims = JwtHelper.GetUserClaims(userData);

        string accessToken = JwtHelper.GetAccessToken(Options, claims);

        string refreshToken =
            await RefreshTokenManager.GetNewTokenAsync(accessToken);

        UserTokens = new UserTokensDto(accessToken, refreshToken);
    }

   


}
