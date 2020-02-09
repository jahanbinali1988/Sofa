using Sofa.SharedKernel.BaseClasses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetUserByIdRequest : RequestBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار اندیس الزامی است")]
        public Guid UserId { get; set; }
    }
}
