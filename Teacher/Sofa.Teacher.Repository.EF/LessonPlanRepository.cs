using Sofa.Teacher.EntityFramework.Context;
using Sofa.EntityFramework.Repository;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository.EF
{
    public class LessonPlanRepository : EfRepositoryBase<LessonPlan, Guid>, ILessonPlanRepository
    {
        public LessonPlanRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
