namespace Membership.Blazor.Entities.Interfaces;
public interface IAuthenticationStateProvider
{
    Task<AuthenticationState> GetAuthenticationStateAsync();
    Task LoginAsync(UserTokensDto userTokensDto);
    Task LogoutAsync();
    Task<UserTokensDto> GetUserTokensAsync();
}
