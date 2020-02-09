using Sofa.Teacher.EntityFramework.Context;
using Sofa.EntityFramework.Repository;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository.EF
{
    public class SyllabusRepository : EfRepositoryBase<Syllabus, Guid>, ISyllabusRepository
    {
        private readonly ApplicationDbContext _context;
        public SyllabusRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
