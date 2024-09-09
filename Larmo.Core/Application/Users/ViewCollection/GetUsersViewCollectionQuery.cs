using Larmo.Shared.Application.Paging;
using MediatR;

namespace Larmo.Core.Application.Users.ViewCollection;

public sealed class GetUsersViewCollectionQuery : PageRequest, IRequest<PageResponse<GetUsersViewCollectionQueryResult>>;