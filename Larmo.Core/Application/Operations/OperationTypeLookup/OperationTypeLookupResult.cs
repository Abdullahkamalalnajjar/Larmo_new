using Larmo.Domain.Domain;

namespace Larmo.Core.Application.Operations.OperationTypeLookup;

public sealed record OperationTypeLookupResult(int Key, OperationType Value);