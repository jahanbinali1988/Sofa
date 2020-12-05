using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;

namespace Sofa.CourseManagement.Repository.EF
{
    public class CourseRepository : EfRepositoryBase<Course, Guid>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
