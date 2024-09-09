using MediatR;

namespace Larmo.Core.Application.Users.ViewDetails;

public sealed class GetUserViewDetailsQuery(string userId) : IRequest<GetUserViewDetailsQueryResult>
{
    public string UserId { get; set; } = userId;
}