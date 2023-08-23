namespace Membership.RefreshTokenManager.Memory;
internal class Token
{
    public string AccessToken { get; set; }
    public DateTime ExpiresAt { get; set; }
}
