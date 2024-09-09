using MediatR;

namespace Larmo.Core.Application.Notifications.MaritalStatusLookup;

public sealed class MaritalStatusLookupQuery : IRequest<MaritalStatusLookupResult[]>;