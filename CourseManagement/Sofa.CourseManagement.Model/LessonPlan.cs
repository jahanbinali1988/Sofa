using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class LessonPlan : BaseEntity
    {
        public LevelEnum Level { get; private set; }

        public Guid SessionId { get; set; }
        public Session Session { get; set; }
        public ICollection<Post> Posts { get; set; }

        public static LessonPlan CreateInstance(LevelEnum level, bool isAvtive)
        {
            return new LessonPlan()
            {
                Id = Guid.NewGuid(),
                Level = level,
                IsActive = isAvtive,
                RowVersion = 0
            };
        }
    }
}
