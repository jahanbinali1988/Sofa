using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.EntityFramework.Repository;
using System;

namespace Sofa.CourseManagement.Repository.EF
{
    public class LessonRepository : EfRepositoryBase<Lesson, Guid>, ILessonRepository
    {
        private readonly ApplicationDbContext _context;
        public LessonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
