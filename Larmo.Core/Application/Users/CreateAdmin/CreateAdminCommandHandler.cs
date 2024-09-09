using Larmo.Core.Repository;
using Larmo.Domain.Domain.Identity;
using Larmo.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Larmo.Core.Application.Users.CreateAdmin;

public class CreateAdminCommandHandler(
    IIdentityRepository<User> identityRepository,
    UserManager<User> userManager,
    RoleManager<IdentityRole<string>> roleManager)
    : IRequestHandler<CreateAdminCommand>
{
    public async Task Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByNameAsync(RoleName.Admin);

        if (role is null)
            throw new Exception(message: "admin role not found to assign this user as admin");

        var user = User.Create(email: "admin@admin.com", "admin", string.Empty);
        var identityResult = await userManager.CreateAsync(user, "P@ssw0rd");
        if (!identityResult.Succeeded)
        {
            var errorMessages = identityResult.Errors.Select(error => error.Description).ToList();
            var errorMessage = string.Join("\n", errorMessages);
            throw new Exception(message: errorMessage);
        }

        await userManager.AddToRoleAsync(user, RoleName.Admin);
    }
}