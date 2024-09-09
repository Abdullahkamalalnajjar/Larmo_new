using Ardalis.Specification;
using Larmo.Domain.Domain.Identity;

namespace Larmo.Core.Application.Users;

public sealed class UserSpecification : Specification<User>
{
    public UserSpecification WithGroupsAndRoles(string normalizedEmail)
    {
        Query.Where(user => user.NormalizedEmail == normalizedEmail)
            .Include(user => user.UserPermissions)
            .ThenInclude(userPermissions => userPermissions.Permission)
            .AsNoTracking();

        return this;
    }

    public UserSpecification ByEmail(string normalizedEmail)
    {
        Query.Where(user => user.NormalizedEmail == normalizedEmail);
        return this;
    }

    public UserSpecification ByPhoneNumber(string phoneNumber)
    {
        Query.Where(user => user.PhoneNumber == phoneNumber);
        return this;
    }
}