using Sofa.CourseManagement.Model;
using Sofa.SharedKernel.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.ApplicationService
{
    public static class CourseConverter
    {
        public static CourseDto Convert(this Course source)
        {
            if (source == null)
            {
                return null;
            }

            return new CourseDto
            {
                AgeRange = source.AgeRange,
                FieldId = source.FieldId,
                Id = source.FieldId,
                IsActive = source.IsActive,
                Title = source.Title
            };
        }

        public static IEnumerable<CourseDto> Convert(this IEnumerable<Course> source)
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
