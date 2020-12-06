using Sofa.CourseManagement.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.ApplicationService
{
    public static class SessionConverter
    {
        public static SessionDto Convert(this Session source)
        {
            if (source == null)
            {
                return null;
            }

            return new SessionDto
            {
                Id = source.Id,
                Title = source.Title,
                IsActive = source.IsActive,
                LessonPlanId = source.LessonPlanId,
                TermId = source.TermId
            };
        }

        public static IEnumerable<SessionDto> Convert(this IEnumerable<Session> source)
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
