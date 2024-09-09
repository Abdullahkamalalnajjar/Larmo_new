using Larmo.Core.Repository;
using Larmo.Domain.Domain.Identity;
using Larmo.Shared.Application.Paging;
using Larmo.Shared.Extension;
using MediatR;

namespace Larmo.Core.Application.Users.ViewCollection;

internal sealed class GetUsersViewCollectionQueryHandler(IIdentityRepository<User> userRepository)
    : IRequestHandler<GetUsersViewCollectionQuery, PageResponse<GetUsersViewCollectionQueryResult>>
{
    public async Task<PageResponse<GetUsersViewCollectionQueryResult>> Handle(GetUsersViewCollectionQuery request,
        CancellationToken cancellationToken)
    {
        var specification = new GetUsersViewCollectionQuerySpecification();
        var users = await userRepository.AsPage(specification)
            .WithPagingOptions(request, cancellationToken: cancellationToken);
        return users;
    }
}