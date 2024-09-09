using Larmo.Shared.Application.Paging;
using MediatR;

namespace Larmo.Core.Application.Operations.ViewCollection;

public sealed class GetOperationCollectionQuery : PageRequest, IRequest<PageResponse<OperationResult>>;