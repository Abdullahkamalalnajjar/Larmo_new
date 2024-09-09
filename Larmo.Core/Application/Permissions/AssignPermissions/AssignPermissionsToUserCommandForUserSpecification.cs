using Ardalis.Specification;
using Larmo.Domain.Domain.Identity;

namespace Larmo.Core.Application.Permissions.AssignPermissions;

internal sealed class AssignPermissionsToUserCommandForUserSpecification : Specification<User>
{
    public AssignPermissionsToUserCommandForUserSpecification(string userId)
    {
        Query.Where(u => u.Id == userId)
            .Include(u => u.UserPermissions);
    }
}