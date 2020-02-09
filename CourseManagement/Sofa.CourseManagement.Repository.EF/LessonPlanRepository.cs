using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.EntityFramework.Repository;
using System;

namespace Sofa.CourseManagement.Repository.EF
{
    public class LessonPlanRepository : EfRepositoryBase<LessonPlan, Guid>, ILessonPlanRepository
    {
        private readonly ApplicationDbContext _context;
        public LessonPlanRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
