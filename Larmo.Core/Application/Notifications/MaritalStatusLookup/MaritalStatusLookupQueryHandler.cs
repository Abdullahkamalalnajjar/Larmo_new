using Larmo.Domain.Domain;
using MediatR;

namespace Larmo.Core.Application.Notifications.MaritalStatusLookup;

internal sealed class MaritalStatusLookupQueryHandler : IRequestHandler<MaritalStatusLookupQuery, MaritalStatusLookupResult[]>
{
    public Task<MaritalStatusLookupResult[]> Handle(MaritalStatusLookupQuery request, CancellationToken cancellationToken)
    {
        var operationTypes = Enum.GetValues<MaritalStatus>();
        var result = operationTypes.Select(t => new MaritalStatusLookupResult((int)t, t)).ToArray();
        return Task.FromResult(result);
    }
}