using Larmo.Core.Repository;
using Larmo.Domain.Domain.Identity;
using MediatR;

namespace Larmo.Core.Application.Permissions.ViewCollection;

internal sealed class GetPermissionsViewCollectionQueryHandler(IIdentityRepository<Permission> permissionRepository)
    : IRequestHandler<GetPermissionsViewCollectionQuery, List<GetPermissionsViewCollectionQueryResult>>
{
    public async Task<List<GetPermissionsViewCollectionQueryResult>> Handle(GetPermissionsViewCollectionQuery request,
        CancellationToken cancellationToken)
    {
        var specification = new GetPermissionsViewCollectionQuerySpecification();
        var permissions = await permissionRepository.ListAsync(specification, cancellationToken);
        return permissions;
    }
}