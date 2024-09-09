using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;

namespace Larmo.Shared.Persistence;

public class Repository<T> : RepositoryBase<T>, IRepository<T>
    where T : class
{
    protected Repository(BaseContext context)
        : base(context, SpecificationEvaluator.Default)
    {
    }

    public IQueryable<T> AsPage(ISpecification<T> specification)
    {
        return ApplySpecification(specification);
    }

    public IQueryable<TResult> AsPage<TResult>(ISpecification<T, TResult> specification)
    {
        return ApplySpecification(specification);
    }
}