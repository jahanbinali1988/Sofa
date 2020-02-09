using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.Dapper.Repository
{
    public interface IDapperRepositoryBase<TEntity, TKey> 
        where TKey : struct
        where TEntity : class, IDisposable, IBaseEntity<TKey>, new()
    {
        void Dispose();

        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);
        bool UpdateRange(IEnumerable<TEntity> entities);
        bool Remove(TKey id);
        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entities);

        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetList(string where);
        IEnumerable<TEntity> GetList(string where, object param);
        IEnumerable<TEntity> GetListPaged(string where, int pageNumber, int rowsPerPage);
        IEnumerable<TEntity> GetListPaged(string where, object param, int pageNumber, int rowsPerPage);
        IEnumerable<TEntity> GetListPaged(string where, object param, string orderBy, int pageNumber, int rowsPerPage);
    }
}
