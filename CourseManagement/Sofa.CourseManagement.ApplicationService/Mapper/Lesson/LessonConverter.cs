using Sofa.CourseManagement.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.ApplicationService
{
    public static class LessonConverter
    {
        public static LessonDto Convert(this Lesson source)
        {
            if (source == null)
            {
                return null;
            }

            return new LessonDto
            {
                Id = source.Id,
                Title = source.Title,
                LessonPlanId = source.LessonPlanId,
                Order = source.Order,
                LessonPlanCaption = source.LessonPlan is null ? "" : source.LessonPlan.Title,
                IsActive = source.IsActive
            };
        }

        public static IEnumerable<LessonDto> Convert(this IEnumerable<Lesson> source)
        {
            if (source == null)
            {
                return null;
            }

            return source
                .Select(x => Convert(x));
        }
    }
}
