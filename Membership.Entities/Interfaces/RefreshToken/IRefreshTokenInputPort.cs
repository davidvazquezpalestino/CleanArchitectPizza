namespace Membership.Entities.Interfaces.RefreshToken;
public interface IRefreshTokenInputPort
{
    Task RefreshTokenAsync(UserTokensDto userTokens);
}
