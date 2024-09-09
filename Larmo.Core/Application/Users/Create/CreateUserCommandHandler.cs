using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Larmo.Core.Repository;
using Larmo.Core.Services;
using Larmo.Domain.Domain.Identity;
using Larmo.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Larmo.Core.Application.Users.Create;

internal sealed class CreateUserCommandHandler(
    IIdentityRepository<User> identityRepository,
    ITokenService tokenService,
    UserManager<User> userManager,
    RoleManager<IdentityRole<string>> roleManager)
    : IRequestHandler<CreateUserCommand, AccessTokenResult>
{
    public async Task<AccessTokenResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var emailSpecification = new UserSpecification().ByEmail(request.Email.ToUpper());
        var isEmailExist = await identityRepository.AnyAsync(emailSpecification, cancellationToken);
        if (isEmailExist)
            throw new NullReferenceException(message: "email already exists");

        var phoneNumberSpecification = new UserSpecification().ByPhoneNumber(request.PhoneNumber);
        var isPhoneNumberExist = await identityRepository.AnyAsync(phoneNumberSpecification, cancellationToken);
        if (isPhoneNumberExist)
            throw new NullReferenceException(message: "phone number already exists");

        var user = User.Create(email: request.Email, userName: request.Username, phoneNumber: request.PhoneNumber);
        var identityResult = await userManager.CreateAsync(user, request.Password);
        if (!identityResult.Succeeded)
        {
            var errorMessages = identityResult.Errors.Select(error => error.Description).ToList();
            var errorMessage = string.Join("\n", errorMessages);
            throw new Exception(message: errorMessage);
        }

        var role = string.Empty;

        if (request.IsAdmin)
        {
            await userManager.AddToRoleAsync(user, RoleName.Admin);
            var roleResult = await roleManager.FindByNameAsync(RoleName.Admin);
            role = roleResult?.Name ?? string.Empty;
        }

        var claim = GenerateClaims(user.Id, user.Email, user.UserName, role, []);
        var token = tokenService.GenerateToken(user.Id, claim);
        var refreshToken = RefreshToken.Create(value: token.RefreshToken.RefreshToken, expireOn: token.RefreshToken.ExpireOn);

        user.SetRefreshToken(refreshToken);
        await identityRepository.UpdateAsync(user, cancellationToken);
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

        return claims;
    }
}