﻿using Sofa.SharedKernel.BaseClasses.Message;
using Sofa.SharedKernel.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.ApplicationService
{
    public class AddTermRequest : LoginRequiredRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن عنوان الزامی است")]
        public string Title { get; set; }

        public bool IsActive { get; set; }

        public string Description { get; set; }

        [GuidValidator(ErrorMessage = "وارد کردن شناسه دوره الزامی است")]
        public Guid CourseId { get; set; }
    }
}
