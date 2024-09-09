using Larmo.Core.Repository;
using MediatR;

namespace Larmo.Core.Application.Operations.ViewDetails;

internal sealed class GetOperationDetailsQueryHandler(IOperationRepository operationRepository)
    : IRequestHandler<GetOperationDetailsQuery, OperationResult>
{
    public async Task<OperationResult> Handle(GetOperationDetailsQuery request, CancellationToken cancellationToken)
    {
        var specification = new OperationSpecification(request.GetOperationId());
        var operation = await operationRepository.FirstOrDefaultAsync(specification, cancellationToken);
        if (operation is null)
            throw new NullReferenceException("no item found");

        return operation;
    }
}