namespace Membership.Entities.Interfaces.RefreshToken;
public interface IRefreshTokenController
{
    Task<UserTokensDto> RefreshTokenAsync(UserTokensDto userTokens);
}
