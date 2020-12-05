using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.Identity.ApplicationService
{
    public class UserInfoViewModel
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; set; }
        public bool IsActive { get; set; }
        public Guid? UserCurrentLevelId { get; set; }
        public Guid? UserCurrentCourseId { get; set; }
        public string UserTitle { get; set; }
    }
}
