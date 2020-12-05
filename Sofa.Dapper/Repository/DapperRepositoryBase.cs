using Dapper;
using Dapper.Contrib.Extensions;
using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sofa.Dapper.Repository
{
    public class DapperRepositoryBase<TEntity, TKey> : IDapperRepositoryBase<TEntity, TKey>
        where TKey : struct
        where TEntity : class, IDisposable, IBaseEntity<TKey>, new()
    {
        protected readonly IDbFactory _dbFactory;
        protected readonly IDbTransaction _transaction;

        public DapperRepositoryBase(IDbFactory dbFactory, IDbTransaction transaction)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }

        public void Dispose()
        {
            _transaction.Dispose();
            _dbFactory.Dispose();
        }

        public IDbFactory Db => _dbFactory;
        public IDbTransaction DbTransaction => _transaction;

        public virtual bool Add(TEntity entity)
        {
            try
            {
                Db.Context().Insert(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual bool AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Db.Context().Insert(entities);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual bool Update(TEntity entity)
        {
            try
            {
                Db.Context().Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual bool UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                Db.Context().Update(entities);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual bool Remove(TKey id)
        {
            return Db.Context().Delete(Get(id));
        }

        public virtual bool Remove(TEntity entity)
        {
            return Db.Context().Delete(entity);
        }

        public virtual bool RemoveRange(IEnumerable<TEntity> entities)
        {
            return Db.Context().Delete(entities);
        }

        public virtual TEntity Get(TKey id)
        {
            return Db.Context().Get<TEntity>(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetList(string.Empty);
        }

        public virtual IEnumerable<TEntity> GetList(string where)
        {
            return GetList(where, null, string.Empty);
        }

        public virtual IEnumerable<TEntity> GetList(string where, object param)
        {
            return GetList(where, param, string.Empty);
        }

        public virtual IEnumerable<TEntity> GetList(string where, object param, string orderBy)
        {
            var query = GetBaseQuery().Where(where).OrderBy(orderBy);

            return GetListSql(query, param);
        }

        public virtual IEnumerable<TEntity> GetListPaged(string where, int pageNumber, int rowsPerPage)
        {
            return GetListPaged(where, null, string.Empty, pageNumber, rowsPerPage);
        }

        public virtual IEnumerable<TEntity> GetListPaged(string where, object param, int pageNumber, int rowsPerPage)
        {
            return GetListPaged(where, param, string.Empty, pageNumber, rowsPerPage);
        }

        public virtual IEnumerable<TEntity> GetListPaged(string where, object param, string orderBy, int pageNumber, int rowsPerPage)
        {
            if (pageNumber < 1 || rowsPerPage < 1)
                throw new ArgumentOutOfRangeException("Arguments pageNumber and rowsPerPage must be greater than 0");

            var query = GetBaseQuery().Where(where).OrderBy(orderBy).Paging(Db.PagingTemplate(pageNumber, rowsPerPage));

            return GetListSql(query, param);
        }

        public virtual IEnumerable<TEntity> GetListSql(string query, object param)
        {
            return Db.Context().Query<TEntity>(query, param);
        }

        public virtual string GetBaseQuery()
        {
            return typeof(TEntity).Select();
        }
    }
}
