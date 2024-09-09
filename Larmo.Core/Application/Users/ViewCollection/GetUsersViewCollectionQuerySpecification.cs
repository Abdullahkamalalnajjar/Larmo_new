using Ardalis.Specification;
using Larmo.Domain.Domain.Identity;

namespace Larmo.Core.Application.Users.ViewCollection;

internal sealed class GetUsersViewCollectionQuerySpecification : Specification<User, GetUsersViewCollectionQueryResult>
{
    public GetUsersViewCollectionQuerySpecification()
    {
        Query.AsNoTracking();
        Query.Select(u => new GetUsersViewCollectionQueryResult
        {
            Id = u.Id,
            Email = u.Email,
            UserName = u.UserName,
            PhoneNumber = u.PhoneNumber,
            CreatedOn = u.CreatedOn
        });
    }
}