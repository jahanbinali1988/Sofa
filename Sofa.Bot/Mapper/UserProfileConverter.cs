using Sofa.Teacher.States;
using Sofa.Teacher.ApplicationService;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.Teacher.Mapper
{
    public static class UserProfileConverter
    {
        public static UserProfile Convert(this UserDto source)
        {
            if (source == null)
            {
                return null;
            }

            return new UserProfile
            {
                Id = source.Id,
                Name = source.UserName,
                PhoneNumber = source.PhoneNumber,
                LastPassedCourse = source.LastCourseId,
                Level = source.Level
            };
        }

        public static IEnumerable<UserProfile> Convert(this IEnumerable<UserDto> source)
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
