using Sofa.SharedKernel.BaseClasses.Message;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.IntegratedTest
{
    public class AddUserRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار نام کاربری الزامی است")]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public short Role { get; set; }
        public bool IsActive { get; set; }
    }
}
