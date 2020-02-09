﻿using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;

namespace Sofa.CourseManagement.Repository
{
    public interface ILessonRepository : IEfRepositoryBase<Lesson, Guid>
    {
    }
}
