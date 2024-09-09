using Larmo.Domain.Domain;

namespace Larmo.Core.Application.Notifications.GenderLookup;

public sealed record GenderLookupResult(int Key, Gender Value);