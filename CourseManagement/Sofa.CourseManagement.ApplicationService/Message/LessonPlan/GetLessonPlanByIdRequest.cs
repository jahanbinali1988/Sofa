using Sofa.SharedKernel.BaseClasses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetLessonPlanByIdRequest : RequestBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار شناسه الزامی است")]
        public Guid LessonPlanId { get; set; }
    }
}
