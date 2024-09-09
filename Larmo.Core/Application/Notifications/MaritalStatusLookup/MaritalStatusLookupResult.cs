using Larmo.Domain.Domain;

namespace Larmo.Core.Application.Notifications.MaritalStatusLookup;

public sealed record MaritalStatusLookupResult(int Key, MaritalStatus Value);