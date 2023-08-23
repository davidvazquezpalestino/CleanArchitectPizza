namespace Membership.Presenters;
internal static class JwtHelper
{
    static SigningCredentials GetSigningCredentials(
        JwtConfigurationOptions options)
    {
        var Key = Encoding.UTF8.GetBytes(options.SecurityKey);
        var Secret = new SymmetricSecurityKey(Key);

        return new SigningCredentials(Secret, SecurityAlgorithms.HmacSha256);
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
        var Handler = new JwtSecurityTokenHandler();
        var Token = Handler.ReadJwtToken(accessToken);
        return Token.Claims
            .Where(c => c.Type == "FullName" || c.Type == ClaimTypes.Name)
            .ToList();       
    }

    public static string GetAccessToken(
        JwtConfigurationOptions options, List<Claim> userClaims)
    {
        SigningCredentials SigningCredentials = GetSigningCredentials(options);

        JwtSecurityToken JwtSecurityToken =
            GetJwtSecurityToken(options, SigningCredentials, userClaims);
        return new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken);
    }
}
