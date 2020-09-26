using Sofa.SharedKernel.BaseClasses.Message;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddPostRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار عنوان الزامی است")]
        public String Title { get; set; }

        [Range(0, short.MaxValue, ErrorMessage = "مفدار وارد شده خارج از حد مجاز است")]
        public short Order { get; set; }

        [Range(0, 3, ErrorMessage = "مفدار وارد شده خارج از حد مجاز است")]
        public short PostType { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن مقدار عنوان الزامی است")]
        public Guid LessonId { get; set; }

        public bool IsActive { get; set; }
    }
}
