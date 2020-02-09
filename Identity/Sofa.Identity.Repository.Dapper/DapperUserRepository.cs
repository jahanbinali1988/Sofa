using Dapper;
using Sofa.Dapper;
using Sofa.Dapper.Repository;
using Sofa.Identity.Model;
using System;
using System.Data;
using System.Linq;

namespace Sofa.Identity.Repository.Dapper
{
    public class DapperUserRepository : DapperRepositoryBase<User, Guid>, IDapperUserRepository
    {
        public DapperUserRepository(IDbFactory dbFactory, IDbTransaction dbTransaction) : base(dbFactory, dbTransaction)
        {
        }

        public User GetByUserName(string username)
        {
            var cmd = new CommandDefinition("select * from dbo.IDN_User where UserName = @Username", new { Username = username }, transaction: DbTransaction);
            return Db.Context().QueryFirstOrDefault<User>(cmd);
        }
    }
}
