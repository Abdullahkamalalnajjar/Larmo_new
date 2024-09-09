using Microsoft.AspNetCore.Authorization;

namespace Larmo.Core.Application.Behaviour;

public class PermissionAuthorizeAttribute(string permission) : AuthorizeAttribute, IAuthorizationRequirement, IAuthorizationRequirementData
{
    public string Permission { get; } = permission;

    public IEnumerable<IAuthorizationRequirement> GetRequirements()
    {
        yield return this;
    }
}