using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Model
{
    public class LessonPlan : BaseEntity
    {
        public string Title { get; set; }
        public LevelEnum Level { get; set; }

        public ICollection<Lesson> Lessons { get; set; }

        public static LessonPlan DefaultFactory(string title, LevelEnum level, bool isAvtive)
        {
            return new LessonPlan()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Level = level,
                IsActive = isAvtive
            };
        }
    }
}
