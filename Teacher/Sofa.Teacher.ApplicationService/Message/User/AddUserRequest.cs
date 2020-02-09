using Sofa.SharedKernel.BaseClasses.Message;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.Teacher.ApplicationService
{
    public class AddUserRequest : LoginRequiredRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public LevelEnum Level { get; set; }

        public Guid LastCourseId { get; set; }
        public Guid LastSyllabusId { get; set; }
    }
}
