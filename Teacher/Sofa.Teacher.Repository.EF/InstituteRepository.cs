using Sofa.EntityFramework.Repository;
using Sofa.Teacher.EntityFramework.Context;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository.EF
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
