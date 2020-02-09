using Sofa.Teacher.Model;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.Teacher.ApplicationService
{
    public static class UserConverter
    {
        public static UserDto Convert(this User source)
        {
            if (source == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = source.Id,
                Email = source.Email,
                UserName = source.UserName,
                FirstName = source.FirstName,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                LastCourseId = source.LastCourseId,
                //LastLevelId = source.LastLevelId,
                Level = source.Level
            };
        }

        public static IEnumerable<UserDto> Convert(this IEnumerable<User> source)
        {
            if (source == null)
            {
                return null;
            }

            return source.Select(x => Convert(x));
        }
    }
}
