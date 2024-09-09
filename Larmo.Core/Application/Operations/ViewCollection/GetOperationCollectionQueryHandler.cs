using Larmo.Core.Repository;
using Larmo.Shared.Application.Paging;
using Larmo.Shared.Extension;
using MediatR;

namespace Larmo.Core.Application.Operations.ViewCollection;

internal sealed class GetOperationCollectionQueryHandler(IOperationRepository operationRepository)
    : IRequestHandler<GetOperationCollectionQuery, PageResponse<OperationResult>>
{
    public async Task<PageResponse<OperationResult>> Handle(GetOperationCollectionQuery request, CancellationToken cancellationToken)
    {
        var operations = await operationRepository.AsPage(new OperationSpecification())
            .WithPagingOptions(request, cancellationToken);

        return operations;
    }
}