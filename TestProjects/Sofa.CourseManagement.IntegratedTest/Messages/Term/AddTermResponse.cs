﻿using Sofa.CourseManagement.IntegratedTest.Utilities;
using System;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class AddTermResponse : ResponseBase
    {
        public Guid NewRecordedId { get; set; }
    }
}
