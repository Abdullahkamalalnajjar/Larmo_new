using MediatR;

namespace Larmo.Core.Application.Notifications.GenderLookup;

public sealed class GenderLookupQuery : IRequest<GenderLookupResult[]>;