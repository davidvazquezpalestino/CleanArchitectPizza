namespace Membership.Entities.Interfaces.RefreshToken;
public interface IRefreshTokenPresenter
{
    UserTokensDto UserTokens { get; }
    Task GenerateTokenAsync(string oldAccessToken);
}
