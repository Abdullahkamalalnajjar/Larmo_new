using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Larmo.Core.Repository;
using Larmo.Core.Services;
using Larmo.Domain.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Larmo.Core.Application.Users.logIn;

internal sealed class LogInCommandHandler(
    IIdentityRepository<User> identityRepository,
    ITokenService tokenService,
    UserManager<User> userManager)
    : IRequestHandler<LogInCommand, AccessTokenResult>
{
    public async Task<AccessTokenResult> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        var emailSpecification = new UserSpecification().WithGroupsAndRoles(request.Email.ToUpper());
        var user = await identityRepository.FirstOrDefaultAsync(emailSpecification, cancellationToken);
        if (user is null)
            throw new NullReferenceException(message: "user not found");

        var isValidPassword = await userManager.CheckPasswordAsync(user, request.Password);
        if (!isValidPassword)
            throw new InvalidOperationException(message: "invalid password");

        var permission = user.UserPermissions.Select(x => x.Permission)
            .Select(r => r.Name)
            .ToArray();

        var roles = await userManager.GetRolesAsync(user);
        var claim = GenerateClaims(user.Id, user.Email, user.UserName, roles.FirstOrDefault(), permission);
        var token = tokenService.GenerateToken(user.Id, claim);
        return token;
    }

    private static List<Claim> GenerateClaims(string userId, string email, string username, string role, string[] permissions)
    {
        List<Claim> claims =
        [
            new Claim(JwtRegisteredClaimNames.Sid, userId),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Name, username),
            //new Claim("permissions", JsonSerializer.Serialize(permissions, JsonSerializerOptions.Default))
        ];

        if (!string.IsNullOrEmpty(role))
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        claims.AddRange(permissions.Select(permission => new Claim(nameof(Permission), permission)));

        return claims;
    }
}