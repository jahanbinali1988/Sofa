using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.EntityFramework.Repository;
using System;

namespace Sofa.CourseManagement.Repository.EF
{
    public class TermRepository : EfRepositoryBase<Term, Guid>, ITermRepository
    {
        public TermRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
