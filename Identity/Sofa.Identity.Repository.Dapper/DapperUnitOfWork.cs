using Sofa.Dapper;
using Sofa.SharedKernel;
using System;
using System.Data;

namespace Sofa.Identity.Repository.Dapper
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private bool _disposed = false;

        public DapperUnitOfWork(IConnectionStringProvider connectionStringProvider)
        {
            var connectionString = connectionStringProvider.GetConnectionString();
            IDbFactory dbFactory = new SqlDbFactory(connectionString);
            Db = dbFactory;
            if (Db.Context().State != ConnectionState.Open) Db.Context().Open();
            DbTransaction = Db.Context().BeginTransaction();
        }

        public IDbFactory Db { get; private set; }
        public IDbTransaction DbTransaction { get; private set; }

        private IDapperUserRepository _userRepository;
        public IDapperUserRepository Users => _userRepository ?? (_userRepository = new DapperUserRepository(Db, DbTransaction));

        private void ResetRepositories()
        {
            _userRepository = null;
        }

        public void Save()
        {
            try
            {
                DbTransaction.Commit();
            }
            catch
            {
                DbTransaction.Rollback();
                throw;
            }
            finally
            {
                DbTransaction.Dispose();
                DbTransaction = Db.Context().BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                if (DbTransaction != null)
                {
                    DbTransaction.Dispose();
                    DbTransaction = null;
                }

                if (Db != null)
                {
                    Db.Dispose();
                    Db = null;
                }

                _disposed = true;
            }
        }
    }
}
