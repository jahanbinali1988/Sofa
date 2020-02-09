using Sofa.Teacher.EntityFramework.Context;
using Sofa.EntityFramework.Repository;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository.EF
{
    public class CourseRepository : EfRepositoryBase<Course, Guid>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
