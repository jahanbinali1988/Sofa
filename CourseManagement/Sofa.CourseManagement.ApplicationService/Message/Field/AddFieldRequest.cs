﻿using Sofa.SharedKernel.BaseClasses.Message;
using Sofa.SharedKernel.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddFieldRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن عنوان الزامی است")]
        public string Title { get; set; }
        [Required(ErrorMessage = "وضعیت فعال بودن رشته را مشخص کنید")]
        public bool IsActive { get; set; }

        [GuidValidator]
        public Guid InstituteId { get; set; }
    }
}
