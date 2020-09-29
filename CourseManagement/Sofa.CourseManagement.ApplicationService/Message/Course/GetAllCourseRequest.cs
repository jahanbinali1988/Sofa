using Sofa.SharedKernel.BaseClasses.Message;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class GetAllCourseRequest : RequestWithPaging
    {
        [GuidValidator(ErrorMessage = "وارد کردن شناسه الزامی است")]
        public Guid FieldId { get; set; }
    }
}
