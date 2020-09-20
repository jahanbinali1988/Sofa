using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class LessonPlan : BaseEntity
    {
        public LevelEnum Level { get; set; }

        public ICollection<Post> Posts { get; set; }

        public static LessonPlan DefaultFactory(LevelEnum level, bool isAvtive)
        {
            return new LessonPlan()
            {
                Id = Guid.NewGuid(),
                Level = level,
                IsActive = isAvtive
            };
        }
    }
}
