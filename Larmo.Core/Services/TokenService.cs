using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Larmo.Core.Services;

public class TokenService(IOptions<TokenConfiguration> options)
    : ITokenService
{
    private readonly TokenConfiguration _tokenConfiguration = options.Value;

    public AccessTokenResult GenerateToken(string userId, IEnumerable<Claim> claims)
    {
        var accessToken = CreateToken(claims);
        var refreshToken = GenerateRefreshToken();

        var result = new AccessTokenResult
        {
            AccessToken = accessToken,
            ExpireOn = DateTime.UtcNow.AddMinutes(_tokenConfiguration.AccessTokenLifeTimeInMinutes),
            RefreshToken = new RefreshTokenResult
            {
                UserId = userId,
                RefreshToken = refreshToken,
                ExpireOn = DateTime.UtcNow.AddMinutes(_tokenConfiguration.RefreshTokenLifeTimeInMinutes)
            }
        };

        return result;
    }

    public AccessTokenResult RefreshToken(AccessTokenResult model)
    {
        //if (model == null)
        //{
        //    return new TokenModel { Message = "Invalid Request" };
        //}
        //var principal = GetPrincipalFromExpiredToken(model.AccessToken);
        //if (principal == null)
        //{
        //    return new TokenModel { Message = "Invalid Refresh Token or Access Token" };
        //}
        //string username = principal.Identity.Name;
        //var user = await _userManager.FindByNameAsync(username);
        //if (user == null || user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        //{
        //    return new TokenModel { Message = "Invalid Refresh Token or Access Token" };
        //}
        //var newAccessToken = CreateToken(principal.Claims.ToList());
        //var newRefreshToken = GenerateRefreshToken();
        //user.RefreshToken = newRefreshToken;
        //await _userManager.UpdateAsync(user);
        //return new TokenModel
        //{
        //    AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
        //    RefreshToken = newRefreshToken
        //};

        throw new NotImplementedException();
    }

    private string CreateToken(IEnumerable<Claim> claims)
    {
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));
        var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _tokenConfiguration.ValidIssuer,
            audience: _tokenConfiguration.ValidAudience,
            expires: DateTime.UtcNow.AddMinutes(_tokenConfiguration.AccessTokenLifeTimeInMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = symmetricKey,
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }
}