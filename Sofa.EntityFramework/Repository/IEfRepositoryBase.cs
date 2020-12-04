using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sofa.EntityFramework.Repository
{
    public interface IEfRepositoryBase<TEntity, TKey>
    {
        bool Add(TEntity entity);
        Task<bool> AddAsync(TEntity entity);
        bool Any(Expression<Func<TEntity, bool>> filter = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);
        int Count(Expression<Func<TEntity, bool>> filter = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null, int pageIndex = 1, int pageSize = 10);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null, int pageIndex = 0, int paeSize = 10);
        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetAsync(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        IEnumerable<TEntity> QueryPage(int offset, int count, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null, bool orderByDescending = true);
        Task<IEnumerable<TEntity>> QueryPageAsync(int offset, int count, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null, bool orderByDescending = true);
        bool Remove(TEntity entity);
        bool Remove(TKey id);
        bool SafeDelete(TEntity entity);
        bool SafeDelete(TKey id);
        bool SetUnchanged(TEntity entitieit);
        bool Update(TEntity entity);
    }
}
