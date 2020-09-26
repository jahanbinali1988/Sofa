using Sofa.SharedKernel.BaseClasses.Message;
using Sofa.SharedKernel.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddCourseRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false,  ErrorMessage = "وارد کردن عنوان الزامی است")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن محدوده سنی الزامی است")]
        public string AgeRange { get; set; }
        
        [Required(ErrorMessage = "وضعیت فعال بودن دوره را مشخص کنید")]
        public bool IsActive { get; set; }
        
        [GuidValidator]
        public Guid FieldId { get; set; }
    }
}
