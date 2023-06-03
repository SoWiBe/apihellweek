using System.Linq.Expressions;
using Extens.Models.Core;

namespace Extens.Core.Repositories;

public interface IRepository<T>
{
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>?> GetAll();
    Task<IEnumerable<T>?> Find(Expression<Func<T, bool>> expression);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task AddRange(IEnumerable<T> entities);
    Task Remove(T entity);
    Task RemoveById(Guid id);
    Task RemoveRange(IEnumerable<T> entities);
}