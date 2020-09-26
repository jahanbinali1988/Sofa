using Sofa.SharedKernel.BaseClasses;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetPostByIdRequest : RequestBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار شناسه الزامی است")]
        public Guid PostId { get; set; }
    }
}
