using Sofa.CourseManagement.Model;
using Sofa.SharedKernel.BaseClasses.Message;
using Sofa.SharedKernel.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddInstituteRequest : LoginRequiredRequest
    {
        public AddressDto Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار عنوان موسسه الزامی است")]
        public string Title { get; set; }

        [Required(ErrorMessage = "وارد کردن مقدار فعال بودن موسسه الزامی است")]
        public bool IsActive { get; set; }
    }
}
