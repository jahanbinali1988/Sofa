﻿using Sofa.CourseManagement.IntegratedTest.Utilities;
using System;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class AddFieldResponse : ResponseBase
    {
        public Guid NewRecordedId { get; set; }
    }
}
