using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;

namespace Sofa.CourseManagement.Repository.EF
{
    public class SessionRepository : EfRepositoryBase<Session, Guid>, ISessionRepository
    {
        public SessionRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
