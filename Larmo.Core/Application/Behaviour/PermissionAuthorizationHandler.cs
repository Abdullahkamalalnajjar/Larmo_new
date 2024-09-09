using Larmo.Domain.Domain.Identity;
using Larmo.Shared.Common;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Larmo.Core.Application.Behaviour;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizeAttribute>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizeAttribute requirement)
    {
        var adminClaims = context.User.FindFirst(c => c.Type == ClaimTypes.Role);
        if (adminClaims is not null && adminClaims.Value == RoleName.Admin)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        var permissionClaims = context.User.FindAll(c => c.Type == nameof(Permission)).ToArray();

        foreach (var claim in permissionClaims)
        {
            if (claim.Value == requirement.Permission)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
        }

        return Task.CompletedTask;
    }
}