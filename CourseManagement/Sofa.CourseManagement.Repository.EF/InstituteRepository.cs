using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;

namespace Sofa.CourseManagement.Repository.EF
{
    public class InstituteRepository : EfRepositoryBase<Institute, Guid>, IInstituteRepository
    {
        private readonly ApplicationDbContext _context;
        public InstituteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
