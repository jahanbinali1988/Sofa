﻿using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetTermByIdResponse : ResponseBase
    {
        public TermDto Term { get; set; }
    }
}
