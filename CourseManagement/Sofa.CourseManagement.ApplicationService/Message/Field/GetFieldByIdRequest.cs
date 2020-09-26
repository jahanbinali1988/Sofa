using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetFieldByIdRequest : RequestBase
    {
        [GuidValidator]
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار اندیس الزامی است")]
        public Guid FieldId { get; set; }
    }
}
