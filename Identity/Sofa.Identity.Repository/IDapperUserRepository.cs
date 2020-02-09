using Sofa.Dapper.Repository;
using Sofa.Identity.Model;
using System;

namespace Sofa.Identity.Repository
{
    public interface IDapperUserRepository : IDapperRepositoryBase<User, Guid>, IDisposable
    {
        User GetByUserName(string username);
    }
}
