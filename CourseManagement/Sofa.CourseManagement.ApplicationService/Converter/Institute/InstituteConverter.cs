using Sofa.CourseManagement.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.ApplicationService
{
    public static class InstituteConverter
    {
        public static InstituteDto Convert(this Institute source)
        {
            if (source == null)
            {
                return null;
            }

            return new InstituteDto
            {
                Title = source.Title,
                Address = source.Address.Convert(),
                Id = source.Id,
                IsActive = source.IsActive,
                WebsiteUrl = source.WebsiteUrl
            };
        }

        public static IEnumerable<InstituteDto> Convert(this IEnumerable<Institute> source)
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
