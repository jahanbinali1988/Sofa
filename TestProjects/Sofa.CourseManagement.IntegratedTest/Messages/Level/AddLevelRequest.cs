using Sofa.SharedKernel.BaseClasses.Message;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.IntegratedTest
{
    public class AddLevelRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار عنوان اتاق الزامی است")]
        public String Title { get; set; }
    }
}
