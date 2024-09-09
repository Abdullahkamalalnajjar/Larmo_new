using Larmo.Shared.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Larmo.Core.Application.Roles.AddAdmin;

public class AddAdminRoleCommandHandler(RoleManager<IdentityRole<string>> roleManager) : IRequestHandler<AddAdminRoleCommand>
{
    public async Task Handle(AddAdminRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new IdentityRole<string>(RoleName.Admin);
        var identityResult = await roleManager.CreateAsync(role);
        if (!identityResult.Succeeded)
        {
            var errorMessages = identityResult.Errors.Select(error => error.Description).ToList();
            var errorMessage = string.Join("\n", errorMessages);
            throw new Exception(message: errorMessage);
        }
    }
}