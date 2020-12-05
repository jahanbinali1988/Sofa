using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetTermByIdRequest : RequestBase
    {
        [GuidValidator]
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار شناسه الزامی است")]
        public Guid TermId { get; set; }
    }
}
