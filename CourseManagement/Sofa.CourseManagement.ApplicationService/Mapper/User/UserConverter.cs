using Sofa.CourseManagement.Model;
using Sofa.SharedKernel.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.ApplicationService
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
                IsActive = source.IsActive,
                LastName = source.LastName,
                PhoneNumber = source.PhoneNumber,
                Role = source.Role,
                Level = source.Level,
                LevelCaption = source.Level.GetDescription(),
                RoleCaption = source.Role.GetDescription()
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
