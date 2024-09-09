using Ardalis.Specification;
using Larmo.Domain.Domain.Identity;

namespace Larmo.Core.Application.Permissions.AssignPermissions;

internal sealed class AssignPermissionsToUserCommandSpecification : Specification<Permission>
{
    public AssignPermissionsToUserCommandSpecification(List<string> permissionsId)
    {
        Query.Where(u => permissionsId.Contains(u.Id));
    }
}