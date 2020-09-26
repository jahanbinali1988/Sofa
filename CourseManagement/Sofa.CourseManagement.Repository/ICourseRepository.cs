using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Repository
{
    public interface ICourseRepository : IEfRepositoryBase<Course, Guid>
    {
    }
}
