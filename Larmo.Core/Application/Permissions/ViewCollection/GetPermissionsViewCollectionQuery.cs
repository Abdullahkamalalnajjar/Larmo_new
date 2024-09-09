using MediatR;

namespace Larmo.Core.Application.Permissions.ViewCollection;

public sealed class GetPermissionsViewCollectionQuery : IRequest<List<GetPermissionsViewCollectionQueryResult>>;