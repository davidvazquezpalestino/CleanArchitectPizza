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
        List<Claim> userClaims = JwtHelper.GetUserClaimsFromToken(oldAccessToken);

        string accessToken = JwtHelper.GetAccessToken(Options, userClaims);

        string refreshToken = 
            await RefreshTokenManager.GetNewTokenAsync(accessToken);

        UserTokens = new UserTokensDto()
        {
            RefreshToken = refreshToken,
            AccessToken = accessToken
        };
    }
}
