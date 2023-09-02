namespace Membership.Presenters;
internal static class JwtHelper
{
    static SigningCredentials GetSigningCredentials(
        JwtConfigurationOptions options)
    {
        var key = Encoding.UTF8.GetBytes(options.SecurityKey);
        SymmetricSecurityKey secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }



    static JwtSecurityToken GetJwtSecurityToken(
        JwtConfigurationOptions options,
        SigningCredentials signingCredentials, List<Claim> claims) =>
        new JwtSecurityToken(
            issuer: options.ValidIssuer,
            audience: options.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(options.ExpireInMinutes),
            signingCredentials: signingCredentials);


    public static List<Claim> GetUserClaims(UserDto userDto) =>
        new List<Claim>
        {
            new Claim(ClaimTypes.Name, userDto.Email),
            new Claim("FullName", $"{userDto.FirstName} {userDto.LastName}".Trim())
        };
    public static List<Claim> GetUserClaimsFromToken(string accessToken)
    {
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        JwtSecurityToken token = handler.ReadJwtToken(accessToken);
        return token.Claims
            .Where(c => c.Type == "FullName" || c.Type == ClaimTypes.Name)
            .ToList();       
    }

    public static string GetAccessToken(
        JwtConfigurationOptions options, List<Claim> userClaims)
    {
        SigningCredentials signingCredentials = GetSigningCredentials(options);

        JwtSecurityToken jwtSecurityToken =
            GetJwtSecurityToken(options, signingCredentials, userClaims);
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
