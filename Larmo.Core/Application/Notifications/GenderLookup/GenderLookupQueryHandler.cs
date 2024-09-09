using Larmo.Domain.Domain;
using MediatR;

namespace Larmo.Core.Application.Notifications.GenderLookup;

internal sealed class GenderLookupQueryHandler : IRequestHandler<GenderLookupQuery, GenderLookupResult[]>
{
    public Task<GenderLookupResult[]> Handle(GenderLookupQuery request, CancellationToken cancellationToken)
    {
        var operationTypes = Enum.GetValues<Gender>();
        var result = operationTypes.Select(t => new GenderLookupResult((int)t, t)).ToArray();
        return Task.FromResult(result);
    }
}