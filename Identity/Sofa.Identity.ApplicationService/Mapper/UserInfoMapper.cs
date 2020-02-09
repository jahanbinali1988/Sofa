using Sofa.Identity.Model;
using System.Collections.Generic;

namespace Sofa.Identity.ApplicationService
{
    static class UserInfoMapper
    {
        public static UserInfoViewModel ToInfoViewModel(this User user)
        {
            return new UserInfoViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                ID = user.Id,
                IsActive = user.IsActive,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                UserName = user.UserName,
                UserCurrentCourseId = user.UserCurrentCourseId,
                UserCurrentLevelId = user.UserCurrentSyllabusId,
                UserTitle = user.UserTitle
            };
        }

        public static IList<UserInfoViewModel> ToInfoViewModel(this IEnumerable<User> users)
        {
            var result = new List<UserInfoViewModel>();

            foreach (var device in users)
            {
                var tmp = device.ToInfoViewModel();
                result.Add(tmp);
            }

            return result;
        }
    }
}
