using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetInstituteByIdRequest : RequestBase
    {
        [GuidValidator]
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار اندیس الزامی است")]
        public Guid InstituteId { get; set; }
    }
}
