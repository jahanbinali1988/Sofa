using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Repository.EF
{
    public class InstituteRepository : EfRepositoryBase<Institute, Guid>, IInstituteRepository
    {
        private readonly ApplicationDbContext _context;
        public InstituteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Institute> GetInstitutesWithFieldsById(Guid instituteId)
        {
            return _context.Query<Institute>().Where(c => c.Id == instituteId).Include(i => i.Fields);
        }
    }
}
