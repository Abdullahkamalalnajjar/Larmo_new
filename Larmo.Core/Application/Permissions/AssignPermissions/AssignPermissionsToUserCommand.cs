using MediatR;

namespace Larmo.Core.Application.Permissions.AssignPermissions;

public sealed class AssignPermissionsToUserCommand : IRequest
{
    public string UserId { get; set; }
    public List<string> PermissionsIds { get; set; }
}