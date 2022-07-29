using Eternal.Data;
using Eternal.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Eternal.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EternalDbContext _dbContext;

        public Repository(EternalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<T?> GetAsync(
            Expression<Func<T, bool>> wherePredicate, 
            Func<IQueryable<T>, IQueryable<T>> queryCustomization)
        {
            var queryable = _dbContext.Set<T>().Where(wherePredicate);
            queryable = queryCustomization.Invoke(queryable);
            var entity = await queryable.FirstOrDefaultAsync();
            return entity;
        }

        public async Task<List<TReturn>> GetListAsync<TReturn>(Expression<Func<T, TReturn>> selectExpression)
        {
            var list = await _dbContext.Set<T>()
                .Select(selectExpression)
                .ToListAsync();

            return list;
        }

        public async Task<List<TReturn>> GetListAsync<TReturn>(Expression<Func<T, TReturn>>? selectExpression = null)
        {
            var queryable = _dbContext.Set<T>().AsQueryable();
            if (selectExpression is not null)
            {
                queryable = queryable.Select(selectExpression);
            }
            var list = await _dbContext.Set<T>()
                .Select(selectExpression)
                .ToListAsync();

            return list;
        }

        public async Task<Pagination<T>> GetPaginationAsync(
            int? page = null,
            Expression<Func<T, bool>>? searchExpression = null,
            Func<IQueryable<T>, IQueryable<T>>? queryCustomization = null)
        {
            var queryable = _dbContext.Set<T>().AsQueryable();
            if (searchExpression is not null)
            {
                queryable = queryable.Where(searchExpression);
            }

            if (queryCustomization is not null)
            {
                queryable = queryCustomization.Invoke(queryable);
            }

            var pagination = new Pagination<T>();
            var paginationInfo = PaginationInfoExtractor.Extract(page, queryable.Count());
            pagination.Records = await queryable
                .Skip(paginationInfo.Skip)
                .Take(paginationInfo.Take)
                .ToListAsync();

            pagination.NumberOfPages = paginationInfo.NumberOfPages;
            return pagination;
        }

        public async Task<T?> CreateAsync(T entity)
        {
            var entry = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<T?> UpdateAsync(T entity)
        {
            var entry = _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var set = _dbContext.Set<T>();
            var entity = await set.FindAsync(id);
            if (entity is not null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task CreateRangeAsync(List<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }        
    }
}
