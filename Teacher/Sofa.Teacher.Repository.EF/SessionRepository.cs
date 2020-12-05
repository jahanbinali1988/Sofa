using Sofa.EntityFramework.Repository;
using Sofa.Teacher.EntityFramework.Context;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository.EF
{
    public class SessionRepository : EfRepositoryBase<Session, Guid>, ISessionRepository
    {
        private readonly ApplicationDbContext _context;
        public SessionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
