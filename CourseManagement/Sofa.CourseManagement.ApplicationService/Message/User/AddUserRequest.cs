using Sofa.SharedKernel.BaseClasses.Message;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddUserRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار نام کاربری الزامی است")]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار شماره تلفن الزامی است")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "فرمت شماره تلفن وارد شده درست نمی باشد")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار رمز عبور الزامی است")]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست")]
        public string Email { get; set; }

        [Range(0, 2, ErrorMessage = "عدد وارد شده برای نقش بزرگتر از حدمجاز است")]
        public short Role { get; set; }

        [Range(0, 2, ErrorMessage = "عدد وارد شده برای سطح بزرگتر از حدمجاز است")]
        public short Level { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }
    }
}
