using Larmo.Core.Repository;
using Larmo.Domain.Domain.Identity;
using MediatR;

namespace Larmo.Core.Application.Users.ViewDetails;

internal sealed class GetUserViewDetailsQueryHandler(IIdentityRepository<User> userRepository)
    : IRequestHandler<GetUserViewDetailsQuery, GetUserViewDetailsQueryResult>
{
    public async Task<GetUserViewDetailsQueryResult> Handle(GetUserViewDetailsQuery request, CancellationToken cancellationToken)
    {
        var specification = new GetUserViewDetailsQuerySpecification(request.UserId);
        var userDetails = await userRepository.FirstOrDefaultAsync(specification, cancellationToken);
        if (userDetails is null)
        {
            throw new Exception(message: "user not found");
        }

        return userDetails;
    }
}