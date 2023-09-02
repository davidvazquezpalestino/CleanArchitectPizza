namespace Membership.Shared.Entities;
public record struct UserTokensDto(
    string AccessToken, string RefreshToken);
