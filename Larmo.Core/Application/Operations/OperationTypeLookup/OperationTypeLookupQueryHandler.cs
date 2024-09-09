using Larmo.Domain.Domain;
using MediatR;

namespace Larmo.Core.Application.Operations.OperationTypeLookup;

internal sealed class OperationTypeLookupQueryHandler : IRequestHandler<OperationTypeLookupQuery, OperationTypeLookupResult[]>
{
    public Task<OperationTypeLookupResult[]> Handle(OperationTypeLookupQuery request, CancellationToken cancellationToken)
    {
        var operationTypes = Enum.GetValues<OperationType>();
        var result = operationTypes.Select(t => new OperationTypeLookupResult((int)t, t)).ToArray();
        return Task.FromResult(result);
    }
}