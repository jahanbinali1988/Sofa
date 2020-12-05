using Sofa.CourseManagement.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.ApplicationService
{
    public static class TermConverter
    {
        public static TermDto Convert(this Term source)
        {
            if (source == null)
            {
                return null;
            }

            return new TermDto
            {
                Id = source.Id,
                Title = source.Title,
                IsActive = source.IsActive,
                CourseId = source.CourseId,
                Description = source.Description
            };
        }

        public static IEnumerable<TermDto> Convert(this IEnumerable<Term> source)
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
