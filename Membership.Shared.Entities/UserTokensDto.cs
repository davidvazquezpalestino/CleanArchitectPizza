namespace Membership.Shared.Entities;
public record struct UserTokensDto(
    string Access_Token, string Refresh_Token);
