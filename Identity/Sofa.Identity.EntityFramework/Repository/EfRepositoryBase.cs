﻿using Microsoft.EntityFrameworkCore;
using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sofa.Identity.EntityFramework.Repository
{
    public abstract class EfRepositoryBase<TEntity, TKey> : IEfRepositoryBase<TEntity, TKey>
                where TKey : struct
                where TEntity : class, IBaseEntity<TKey>
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
                _context.Entry<TEntity>(entity).State = EntityState.Added;
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
                //_context.Entry<TEntity>(entity).State = EntityState.Added;
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

        public TEntity Get(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return _dbSet.Where<TEntity>(c => c.Id.Equals(id)).Include(c => includes).SingleOrDefault();
        }

        public IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return _dbSet.OrderBy(o => orderBy).Include(i => includes).ToArray<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return await _dbSet.OrderBy(o => orderBy).Include(i => includes).ToArrayAsync<TEntity>();
        }

        public Task<TEntity> GetAsync(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return _dbSet.Where<TEntity>(c => c.Id.Equals(id)).Include(c => includes).SingleOrDefaultAsync();
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return _dbSet.Where(filter).OrderBy(o => orderBy).Include(i => includes).ToArray<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return await _dbSet.Where(filter).OrderBy(o => orderBy).Include(i => includes).ToArrayAsync<TEntity>();
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
                _context.Entry<TEntity>(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
