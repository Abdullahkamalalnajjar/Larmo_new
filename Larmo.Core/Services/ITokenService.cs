using System.Security.Claims;

namespace Larmo.Core.Services;

public interface ITokenService
{
    AccessTokenResult GenerateToken(string userId, IEnumerable<Claim> claims);
    AccessTokenResult RefreshToken(AccessTokenResult model);
}