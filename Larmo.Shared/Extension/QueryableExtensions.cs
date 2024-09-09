using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Larmo.Shared.Application.Paging;
using Microsoft.EntityFrameworkCore;

namespace Larmo.Shared.Extension;

public static class QueryableExtensions
{
    public static IEnumerable<T> Expand<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> elementSelector)
    {
        Stack<IEnumerator<T>> stack = new();
        var e = source.GetEnumerator();
        try
        {
            while (true)
            {
                while (e.MoveNext())
                {
                    var item = e.Current;
                    yield return item;
                    var elements = elementSelector(item);
                    if (elements == null)
                    {
                        continue;
                    }

                    stack.Push(e);
                    e = elements.GetEnumerator();
                }

                if (stack.Count == 0)
                {
                    break;
                }

                e.Dispose();
                e = stack.Pop();
            }
        }
        finally
        {
            e.Dispose();
            while (stack.Count != 0)
            {
                stack.Pop().Dispose();
            }
        }
    }

    public static async Task<PageResponse<T>> WithPagingOptions<T>(this IQueryable<T> query,
        PageRequest pageRequest, CancellationToken cancellationToken = default)
    {
        var pageNumber = pageRequest.PagingOptions.PageNumber;
        var pageSize = pageRequest.PagingOptions.PageSize;

        if (pageRequest.SortingField != null)
        {
            var propInfo = GetPropertyInfo(typeof(T), pageRequest.SortingField.Field);
            var expr = GetOrderExpression(typeof(T), propInfo);

            MethodInfo method;

            if (pageRequest.SortingField.Direction == SortDirection.Descending)
            {
                method = typeof(Queryable).GetMethods()
                    .FirstOrDefault(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);
            }
            else
            {
                method = typeof(Queryable).GetMethods()
                    .FirstOrDefault(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
            }

            var genericMethod = method!.MakeGenericMethod(typeof(T), propInfo.PropertyType);
            query = (IQueryable<T>)genericMethod.Invoke(null, new object[] { query, expr });
        }

        if (!string.IsNullOrEmpty(pageRequest.Filter))
        {
            query = query.AddFilter(pageRequest.Filter);
        }

        if (string.IsNullOrEmpty(pageRequest.Filter) && pageRequest.FilterBuilder != null &&
            !string.IsNullOrEmpty(pageRequest.FilterBuilder.Term))
        {
            pageRequest.FilterBuilder.Term = pageRequest.FilterBuilder.Term.Trim();
            if (GetOperation(pageRequest.FilterBuilder.Operation, pageRequest.FilterBuilder.Term) != "none")
            {
                if (string.IsNullOrEmpty(pageRequest.FilterBuilder.Field))
                {
                    var propertiesInfo = typeof(T).GetProperties()
                        .Where(c => c.PropertyType == typeof(string))
                        .ToList();
                    query = query!.Where(GetWhereExpression<T, bool>(pageRequest.FilterBuilder.Term,
                        pageRequest.FilterBuilder.Operation, propertiesInfo.ToArray()));
                }
                else
                {
                    if (pageRequest.FilterBuilder.Field.Contains(","))
                    {
                        var properties = pageRequest.FilterBuilder.Field.Split(",").ToList();
                        List<PropertyInfo> propertyInfos = new();
                        properties.ForEach(c => propertyInfos.Add(GetPropertyInfo(typeof(T), c)));
                        query = query!.Where(GetWhereExpression<T, bool>(pageRequest.FilterBuilder.Term,
                            pageRequest.FilterBuilder.Operation, propertyInfos.ToArray()));
                    }
                    else
                    {
                        var propInfo = GetPropertyInfo(typeof(T), pageRequest.FilterBuilder.Field);
                        query = query!.Where(GetWhereExpression<T, bool>(pageRequest.FilterBuilder.Term,
                            pageRequest.FilterBuilder.Operation, propInfo));
                    }
                }
            }
        }

        var count = await query!.CountAsync(cancellationToken);
        var result =
            await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
        return new PageResponse<T>(result, count, pageNumber, pageSize);
    }

    public static IQueryable<TEntity> AddFilter<TEntity>(this IQueryable<TEntity> source, string filter)
    {
        if (!string.IsNullOrWhiteSpace(filter))
        {
            var filterExpression = GetSelectorExpression<TEntity, bool>(filter);
            return source.Where(filterExpression);
        }

        return source;
    }

    private static PropertyInfo GetPropertyInfo(Type objType, string name)
    {
        var properties = objType.GetProperties();
        var matchedProperty = properties.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        if (matchedProperty == null)
        {
            throw new ArgumentException($"could not find the field {name}");
        }

        return matchedProperty;
    }

    private static LambdaExpression GetOrderExpression(Type objType, PropertyInfo pi)
    {
        var paramExpr = Expression.Parameter(objType);
        var propAccess = Expression.PropertyOrField(paramExpr, pi.Name);
        var expr = Expression.Lambda(propAccess, paramExpr);
        return expr;
    }

    private static Expression<Func<T, TResult>> GetWhereExpression<T, TResult>(string term,
        FilterOperation operation, params PropertyInfo[] propertiesInfoList)
    {
        StringBuilder stringExpressions = new();
        foreach (var propertyInfo in propertiesInfoList)
        {
            if (stringExpressions.Length > 0)
            {
                stringExpressions.Append(" || ");
            }

            stringExpressions.Append($"{propertyInfo.Name}{GetOperation(operation, term)}");
        }

        return GetSelectorExpression<T, TResult>(stringExpressions.ToString());
    }

    private static Expression<Func<TEntity, TResult>> GetSelectorExpression<TEntity, TResult>(
        string selectorExpression)
    {
        var parameterExpression = Expression.Parameter(typeof(TEntity));
        var result =
            (Expression<Func<TEntity, TResult>>)DynamicExpressionParser.ParseLambda(new[] { parameterExpression },
                typeof(TResult), selectorExpression);

        return result;
    }

    private static string GetOperation(FilterOperation operation, string term)
    {
        switch (operation)
        {
            case FilterOperation.Contains:
                return $".ToLower().Contains(\"{term.ToLower()}\")";
            case FilterOperation.NotContains:
                return $".ToLower().Contains(\"{term.ToLower()}\")==false";
            case FilterOperation.Equal:
                return $" eq \"{term}\"";
            case FilterOperation.GreaterThan:
                return $" gt \"{term}\"";
            case FilterOperation.GreaterThanOrEqual:
                return $" ge \"{term}\"";
            case FilterOperation.LessThan:
                return $" lt \"{term}\"";
            case FilterOperation.LessThanOrEqual:
                return $" le \"{term}\"";
            case FilterOperation.NotEqual:
                return $" <> \"{term}\"";
            default:
                return "none";
        }
    }
}
