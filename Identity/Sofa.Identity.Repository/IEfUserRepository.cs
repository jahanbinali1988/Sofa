using Sofa.Identity.EntityFramework.Repository;
using Sofa.Identity.Model;
using System;

namespace Sofa.Identity.Repository
{
    public interface IEfUserRepository : IEfRepositoryBase<User, Guid>
    {
        User GetByUserName(string name);
    }
}
