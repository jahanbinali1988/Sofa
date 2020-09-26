using Sofa.CourseManagement.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.ApplicationService
{
    public static class FieldConverter
    {
        public static FieldDto Convert(this Field source)
        {
            if (source == null)
            {
                return null;
            }

            return new FieldDto
            {
                Id = source.Id,
                Title = source.Title,
                IsActive = source.IsActive,
                InstituteId = source.InstituteId
            };
        }

        public static IEnumerable<FieldDto> Convert(this IEnumerable<Field> source)
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
