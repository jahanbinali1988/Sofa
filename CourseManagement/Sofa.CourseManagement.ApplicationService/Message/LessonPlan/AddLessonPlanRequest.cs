using Sofa.SharedKernel.BaseClasses.Message;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddLessonPlanRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار عنوان برنامه تحصیلی الزامی است")]
        public String Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار سطح برنامه تحصیلی الزامی است")]
        [Range(0, 2, ErrorMessage = "مفدار وارد شده خارج از حد مجاز است")]
        public short Level { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن جلسه الزامی است")]
        public Guid SessionId { get; set; }

        [Required(ErrorMessage = "وضعیت فعال بودن برنامه آموزش را مشخص کنید")]
        public bool IsActive { get; set; }

        public string Description { get; set; }
    }
}
