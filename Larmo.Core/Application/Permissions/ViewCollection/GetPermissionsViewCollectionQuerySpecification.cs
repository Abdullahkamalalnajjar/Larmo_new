using Ardalis.Specification;
using Larmo.Domain.Domain.Identity;

namespace Larmo.Core.Application.Permissions.ViewCollection;

internal sealed class GetPermissionsViewCollectionQuerySpecification
    : Specification<Permission, GetPermissionsViewCollectionQueryResult>
{
    public GetPermissionsViewCollectionQuerySpecification()
    {
        Query.AsNoTracking();
        Query.Select(p => new GetPermissionsViewCollectionQueryResult
        {
            Id = p.Id,
            Name = p.Name,
            ModuleName = p.ModuleName,
            DependOn = p.DependOn
        });
    }
}