using Eternal.Models;
using System.Linq.Expressions;

namespace Eternal.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task<T?> CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<TReturn>> GetListAsync<TReturn>(Expression<Func<T, TReturn>> selectExpression);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> wherePredicate);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetAsync(Expression<Func<T, bool>> wherePredicate, Func<IQueryable<T>, IQueryable<T>> queryCustomization);
        Task<Pagination<T>> GetPaginationAsync(int? page = null, Expression<Func<T, bool>>? searchExpression = null, Func<IQueryable<T>, IQueryable<T>>? queryCustomization = null);
        Task<T?> UpdateAsync(T entity);
        Task CreateRangeAsync(List<T> entities);
    }
}