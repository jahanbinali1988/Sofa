﻿using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class SessionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        public Guid TermId { get; set; }
        public Guid LessonPlanId { get; set; }
    }
}
