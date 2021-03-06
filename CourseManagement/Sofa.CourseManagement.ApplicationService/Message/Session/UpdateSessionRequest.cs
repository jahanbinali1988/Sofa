﻿using Sofa.SharedKernel.BaseClasses.Message;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UpdateSessionRequest : LoginRequiredRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public Guid TermId { get; set; }
        public Guid LessonPlanId { get; set; }
    }
}
