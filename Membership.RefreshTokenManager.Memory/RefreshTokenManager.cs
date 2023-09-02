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
        Tokens.TryRemove(refreshToken, out Token token);
        return Task.CompletedTask;
    }

    public Task ThrowIfNotCanGetNewTokenAsync(
        string refreshToken, string accessToken)
    {
        if (Tokens.TryGetValue(refreshToken, out Token token))
        { 
            Tokens.TryRemove(refreshToken, out token);
            if (token != null && token.AccessToken != accessToken)
                throw new RefreshTokenCompromisedException(refreshToken);
            if (token != null && token.ExpiresAt < DateTime.UtcNow)
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
        string refreshToken = GenerateToken();
        Token token = new Token
        {
            AccessToken = accesToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(Options.RefreshTokenExpireInMinutes)
        };

        if (!Tokens.TryAdd(refreshToken, token))
        {
            refreshToken = null;
        }

        return Task.FromResult(refreshToken);
    }

    private string GenerateToken()
    {
        // 6 bits => 1 caracter de una cadena base64
        // N Bytes => 100 caracteres base64
        
        var buffer = new byte[75];
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        rng.GetBytes(buffer);
        return Convert.ToBase64String(buffer);
    }
}
