using MediatR;

namespace Larmo.Core.Application.Operations.OperationTypeLookup;

public sealed class OperationTypeLookupQuery : IRequest<OperationTypeLookupResult[]>;