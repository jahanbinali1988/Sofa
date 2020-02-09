using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;

namespace Sofa.CourseManagement.Repository
{
    public interface IUserRepository : IEfRepositoryBase<User, Guid>
    {
        User GetByUserName(string name);
    }
}
