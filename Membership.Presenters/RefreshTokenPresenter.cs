namespace Membership.Presenters;
internal class RefreshTokenPresenter : IRefreshTokenPresenter
{
    readonly JwtConfigurationOptions Options;
    readonly IRefreshTokenManager RefreshTokenManager;

    public RefreshTokenPresenter(IOptions<JwtConfigurationOptions> options, 
        IRefreshTokenManager refreshTokenManager)
    {
        Options = options.Value;
        RefreshTokenManager = refreshTokenManager;
    }

    public UserTokensDto UserTokens { get; private set; }

    public async Task GenerateTokenAsync(string oldAccessToken)
    {
        List<Claim> UserClaims = JwtHelper.GetUserClaimsFromToken(oldAccessToken);

        string AccessToken = JwtHelper.GetAccessToken(Options, UserClaims);

        string RefreshToken = 
            await RefreshTokenManager.GetNewTokenAsync(AccessToken);

        UserTokens = new UserTokensDto()
        {
            Refresh_Token = RefreshToken,
            Access_Token = AccessToken
        };
    }
}
