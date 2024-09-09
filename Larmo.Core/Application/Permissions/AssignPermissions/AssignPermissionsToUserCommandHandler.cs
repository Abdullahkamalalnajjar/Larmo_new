using Larmo.Core.Repository;
using Larmo.Domain.Domain.Identity;
using MediatR;

namespace Larmo.Core.Application.Permissions.AssignPermissions;

internal sealed class AssignPermissionsToUserCommandHandler(
    IIdentityRepository<Permission> permissionsRepository,
    IIdentityRepository<User> usersRepository)
    : IRequestHandler<AssignPermissionsToUserCommand>
{
    public async Task Handle(AssignPermissionsToUserCommand request, CancellationToken cancellationToken)
    {
        var specification = new AssignPermissionsToUserCommandForUserSpecification(request.UserId);
        var user = await usersRepository.FirstOrDefaultAsync(specification, cancellationToken);
        if (user is null)
            throw new Exception(message: "user not found");

        var permissions = await permissionsRepository.ListAsync(new AssignPermissionsToUserCommandSpecification(request.PermissionsIds),
            cancellationToken);

        if (permissions.Count != request.PermissionsIds.Count)
            throw new Exception(message: "there is invalid permissions");

        user.ClearPermission();
        foreach (var id in request.PermissionsIds)
        {
            var permission = permissions.Find(p => p.Id == id);
            user.AddToPermission(permission);
        }

        await usersRepository.UpdateAsync(user, cancellationToken);
    }
}