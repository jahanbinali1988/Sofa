using Sofa.CourseManagement.Model;
using Sofa.SharedKernel.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.ApplicationService
{
    public static class LessonPlanConverter
    {
        public static LessonPlanDto Convert(this LessonPlan source)
        {
            if (source == null)
            {
                return null;
            }

            return new LessonPlanDto
            {
                Id = source.Id,
                Title = source.Title,
                Level = source.Level,
                LevelCaption = source.Level.GetDescription()
            };
        }

        public static IEnumerable<LessonPlanDto> Convert(this IEnumerable<LessonPlan> source)
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
