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
        List<Claim> Claims = JwtHelper.GetUserClaims(userData);

        string AccessToken = JwtHelper.GetAccessToken(Options, Claims);

        string RefreshToken =
            await RefreshTokenManager.GetNewTokenAsync(AccessToken);

        UserTokens = new UserTokensDto(AccessToken, RefreshToken);
    }

   


}
