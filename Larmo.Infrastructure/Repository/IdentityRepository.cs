using Larmo.Core.Repository;
using Larmo.Infrastructure.Context;
using Larmo.Shared.Persistence;

namespace Larmo.Infrastructure.Repository;

public class IdentityRepository<T>(ApplicationContext context)
    : Repository<T>(context), IIdentityRepository<T>
    where T : class;