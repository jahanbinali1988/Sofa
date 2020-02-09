using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddLessonRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار عنوان درس الزامی است")]
        public String Title { get; set; }

        [Required(ErrorMessage ="وارد کردن شماره درس الزامی می باشد")]
        [Range(0, short.MaxValue)]
        public short Order { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن اندیس برنامه تحصیلی موردنظر الزامی است")]
        public Guid LessonPlanId { get; set; }

        public bool IsActive { get; set; }
    }
}
