using Ardalis.Specification;
using Larmo.Domain.Domain.Identity;

namespace Larmo.Core.Application.Users.ViewDetails;

internal sealed class GetUserViewDetailsQuerySpecification : Specification<User, GetUserViewDetailsQueryResult>
{
    public GetUserViewDetailsQuerySpecification(string userId)
    {
        Query.Where(u => u.Id == userId).AsNoTracking();
        Query.Select(u => new GetUserViewDetailsQueryResult
        {
            Id = u.Id,
            Email = u.Email,
            UserName = u.UserName,
            PhoneNumber = u.PhoneNumber,
            CreatedOn = u.CreatedOn,
            Permissions = u.UserPermissions.Select(up => new GetUserPermissionViewDetailsQueryResult
            {
                Id = up.Permission.Id,
                Name = up.Permission.Name,
                ModuleName = up.Permission.ModuleName,
                DependOn = up.Permission.DependOn
            }).ToList()
        });
    }
}