﻿using Eternal.Models;
using System.Linq.Expressions;

namespace Eternal.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task<T?> CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<TReturn>> GetAllAsync<TReturn>(Expression<Func<T, TReturn>> selectExpression);
        Task<T?> GetByIdAsync(int id);
        Task<Pagination<T>> GetPaginationAsync(int? page = null, Expression<Func<T, bool>>? searchExpression = null, Func<IQueryable<T>, IQueryable<T>>? queryCustomization = null);
        Task<T?> UpdateAsync(T entity);
        Task CreateRangeAsync(List<T> entities);
    }
}