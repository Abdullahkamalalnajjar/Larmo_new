using Larmo.Shared.Persistence;

namespace Larmo.Core.Repository;

public interface IIdentityRepository<T> : IRepository<T>
    where T : class;