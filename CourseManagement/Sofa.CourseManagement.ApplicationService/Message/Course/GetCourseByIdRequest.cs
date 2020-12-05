using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetCourseByIdRequest : RequestBase
    {
        [GuidValidator]
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار اندیس الزامی است")]
        public Guid CourseId { get; set; }
    }
}
