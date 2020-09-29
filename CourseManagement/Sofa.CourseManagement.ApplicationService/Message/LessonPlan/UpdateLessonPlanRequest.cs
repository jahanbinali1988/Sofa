using Sofa.SharedKernel.BaseClasses.Message;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdateLessonPlanRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن شناسه برنامه تحصیلی الزامی است")]
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن عنوان برنامه تحصیلی الزامی است")]
        public String Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن سطح برنامه تحصیلی الزامی است")]
        [Range(0, 2, ErrorMessage = "مفدار وارد شده خارج از حد مجاز است")]
        public short Level { get; set; }
        [Required(ErrorMessage = "وضعیت فعال بودن برنامه آموزش را مشخص کنید")]
        public bool IsActive { get; set; }
    }
}
