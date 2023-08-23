namespace Membership.Entities.Interfaces;
public interface IRefreshTokenManager
{
    Task<string> GetNewTokenAsync(string accessToken);
    Task DeleteTokenAsync(string refreshToken);
    Task ThrowIfNotCanGetNewTokenAsync(string refreshToken, string accessToken);
}

//TODO: Implementar el RefreshTokenManager
