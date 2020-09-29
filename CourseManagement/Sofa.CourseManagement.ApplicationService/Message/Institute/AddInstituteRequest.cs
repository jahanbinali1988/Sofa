using Sofa.SharedKernel.BaseClasses.Message;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddInstituteRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار عنوان موسسه الزامی است")]
        public string Title { get; set; }

        [Required(ErrorMessage = "وارد کردن مقدار فعال بودن موسسه الزامی است")]
        public bool IsActive { get; set; }

        public AddressDto Address { get; set; }

        public string WebsiteUrl { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار کد موسسه الزامی است")]
        public string Code { get; set; }

    }
}
