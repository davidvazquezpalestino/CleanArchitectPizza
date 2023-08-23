namespace Membership.RefreshTokenManager.Memory;
internal class RefreshTokenManager : IRefreshTokenManager
{
    readonly ConcurrentDictionary<string, Token> Tokens = new();
    readonly JwtConfigurationOptions Options;

    public RefreshTokenManager(IOptions<JwtConfigurationOptions> options)
    {
        Options = options.Value;
    }

    public Task DeleteTokenAsync(string refreshToken)
    {
        Tokens.TryRemove(refreshToken, out Token _);
        return Task.CompletedTask;
    }

    public Task ThrowIfNotCanGetNewTokenAsync(
        string refreshToken, string accessToken)
    {
        if (Tokens.TryGetValue(refreshToken, out Token Token))
        { 
            Tokens.TryRemove(refreshToken, out Token);
            if (Token.AccessToken != accessToken)
                throw new RefreshTokenCompromisedException(refreshToken);
            if (Token.ExpiresAt < DateTime.UtcNow)
                throw new RefreshTokenExpiredException(refreshToken);           
        }
        else
        {
            throw new RefreshTokenNotFoundException();
        }
        return Task.CompletedTask;
    }

    public Task<string> GetNewTokenAsync(string accesToken)
    {
        string RefreshToken = GenerateToken();
        Token Token = new Token
        {
            AccessToken = accesToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(
                Options.RefreshTokenExpireInMinutes)
        };

        if (!Tokens.TryAdd(RefreshToken, Token))
        {
            RefreshToken = null;
        }

        return Task.FromResult(RefreshToken);
    }

    private string GenerateToken()
    {
        // 6 bits => 1 caracter de una cadena base64
        // N Bytes => 100 caracteres base64
        
        var Buffer = new byte[75];
        using var Rng = RandomNumberGenerator.Create();
        Rng.GetBytes(Buffer);
        return Convert.ToBase64String(Buffer);
    }
}
