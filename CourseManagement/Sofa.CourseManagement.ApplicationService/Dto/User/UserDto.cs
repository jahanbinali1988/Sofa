using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; set; }
        public string RoleCaption { get; set; }
        public LevelEnum Level { get; set; }
        public string LevelCaption { get; set; }
        public bool IsActive { get; set; }
    }
}
