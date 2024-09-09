using Ardalis.Specification;

namespace Larmo.Shared.Persistence;

public interface IRepository<T> : IRepositoryBase<T>
    where T : class
{
    IQueryable<T> AsPage(ISpecification<T> specification);
    IQueryable<TResult> AsPage<TResult>(ISpecification<T, TResult> specification);
}