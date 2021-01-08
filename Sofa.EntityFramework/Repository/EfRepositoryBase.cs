using Microsoft.EntityFrameworkCore;
using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sofa.EntityFramework.Repository
{
    public abstract class EfRepositoryBase<TEntity, TKey> : IEfRepositoryBase<TEntity, TKey>
            where TKey : struct
            where TEntity : BaseEntity, IBaseEntity<TKey>
    {
        protected DbContext _context { get; }
        protected DbSet<TEntity> _dbSet = null;
        public EfRepositoryBase(DbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public bool Add(TEntity entity)
        {
            try
            {
                //_context.Entry<TEntity>(entity).State = EntityState.Added;
                _context.Add<TEntity>(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await _context.AddAsync<TEntity>(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dbSet.Any<TEntity>(filter);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dbSet.AnyAsync<TEntity>(filter);
        }

        public int Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dbSet.Count<TEntity>(filter);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dbSet.CountAsync<TEntity>(filter);
        }

        public TEntity Get(TKey id)
        {
            return _dbSet.Where<TEntity>(c => c.Id.Equals(id)).SingleOrDefault();
        }

        public TEntity GetWithIncluded(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return _dbSet.Where<TEntity>(c => c.Id.Equals(id)).Include(c => includes).SingleOrDefault();
        }

        public IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null, int pageIndex = 1, int pageSize = 10)
        {
            IQueryable<TEntity> result = _dbSet.AsQueryable<TEntity>();
            if (orderBy != null)
                result = result.OrderBy(o => orderBy);
            if (includes != null)
                result = result.Include(i => includes);
            int skipSize = (pageIndex - 1) * pageSize;
            return result.Skip(skipSize).Take(pageSize).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null, int pageIndex = 1, int pageSize = 10)
        {
            return await _dbSet.OrderBy(o => orderBy).Include(i => includes).ToArrayAsync<TEntity>();
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            return _dbSet.Where<TEntity>(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TEntity> GetAsync(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return _dbSet.Where<TEntity>(c => c.Id.Equals(id)).Include(c => includes).SingleOrDefaultAsync();
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (includes is null)
            {
                if (orderBy is null)
                    return _dbSet.Where(filter).ToArray<TEntity>();
                else
                    return _dbSet.Where(filter).OrderBy(o => orderBy).ToArray<TEntity>();

            }
            else
            {
                if (orderBy is null)
                    return _dbSet.Where(filter).Include(i => includes).ToArray<TEntity>();
                else
                    return _dbSet.Where(filter).OrderBy(o => orderBy).Include(i => includes).ToArray<TEntity>();
            }
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            if (includes is null)
            {
                if (orderBy is null)
                    return await _dbSet.Where(filter).ToArrayAsync<TEntity>();
                else
                    return await _dbSet.Where(filter).OrderBy(o => orderBy).ToArrayAsync<TEntity>();

            }
            else
            {
                if (orderBy is null)
                    return await _dbSet.Where(filter).Include(i => includes).ToArrayAsync<TEntity>();
                else
                    return await _dbSet.Where(filter).OrderBy(o => orderBy).Include(i => includes).ToArrayAsync<TEntity>();
            }
        }

        public IEnumerable<TEntity> QueryPage(int offset, int count, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null, bool orderByDescending = true)
        {
            var query = _dbSet.Where(filter);

            if (orderBy != null)
                query = orderByDescending ? query.OrderByDescending(o => orderBy) : query.OrderBy(o => orderBy);
            else
                query = query.OrderByDescending(c => c.Id);

            if (includes != null)
                query = query.Include(i => includes);

            return query.Skip(offset).Take(count).ToArray<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> QueryPageAsync(int offset, int count, Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null, bool orderByDescending = true)
        {
            var query = _dbSet.Where(filter);

            if (orderBy != null)
                query = orderByDescending ? query.OrderByDescending(o => orderBy) : query.OrderBy(o => orderBy);
            else
                query = query.OrderByDescending(c => c.Id);

            if (includes != null)
                query = query.Include(i => includes);

            return await query.Skip(offset).Take(count).ToArrayAsync<TEntity>();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _context.Entry<TEntity>(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Remove(TKey id)
        {
            try
            {
                var entity = _dbSet.SingleOrDefault(c => c.Id.Equals(id));
                if (!(entity is null))
                {
                    _context.Entry<TEntity>(entity).State = EntityState.Deleted;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SetUnchanged(TEntity entity)
        {
            try
            {
                _context.Entry<TEntity>(entity).State = EntityState.Unchanged;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                entity.AssignModifiedDate(DateTime.Now);
                entity.IncreaseRowVersion();
                _context.Update<TEntity>(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SafeDelete(TEntity entity)
        {
            bool result = false;
            try
            {
                entity.AssignIsDeleted(true);
                entity.AssignModifiedDate(DateTime.Now);
                entity.IncreaseRowVersion();
                _context.Update<TEntity>(entity);
                result= true;
            }
            catch (Exception)
            {
            }
            return result;
        }

        public bool SafeDelete(TKey id)
        {
            bool result = false;
            try
            {
                var entity = _dbSet.SingleOrDefault<TEntity>(c => c.Id.Equals(id));
                if (entity != null)
                {
                    entity.AssignIsDeleted(true);
                    entity.AssignModifiedDate(DateTime.Now);
                    entity.IncreaseRowVersion();
                    _context.Update<TEntity>(entity);
                }
                result = true;
            }
            catch (Exception)
            {
            }
            return result;
        }

        public bool ChangeActiveStatus(TEntity entity)
        {
            bool result = false;
            try
            {
                entity.AssignIsActive();
                entity.AssignModifiedDate(DateTime.Now);
                entity.IncreaseRowVersion();
                _context.Update<TEntity>(entity);
                result= true;
            }
            catch (Exception)
            {
            }
            return result;
        }

        public bool ChangeActiveStatus(TKey id)
        {
            bool result = false;
            try
            {
                var entity = _dbSet.SingleOrDefault<TEntity>(c => c.Id.Equals(id));
                if (entity != null)
                {
                    entity.AssignIsActive();
                    entity.AssignModifiedDate(DateTime.Now);
                    entity.IncreaseRowVersion();
                    _context.Update<TEntity>(entity);
                }
                result = true;
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
