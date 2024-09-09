using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Larmo.Core.Application.Roles.Add;

public class AddRoleCommandHandler(RoleManager<IdentityRole<string>> roleManager) : IRequestHandler<AddRoleCommand>
{
    public async Task Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new IdentityRole<string>(request.Name);
        var identityResult = await roleManager.CreateAsync(role);
        if (!identityResult.Succeeded)
        {
            var errorMessages = identityResult.Errors.Select(error => error.Description).ToList();
            var errorMessage = string.Join("\n", errorMessages);
            throw new Exception(message: errorMessage);
        }
    }
}