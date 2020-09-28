using Sofa.CourseManagement.IntegratedTest.Utilities;
using System;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class AddCourseResponse : ResponseBase
    {
        public Guid NewRecordedId { get; set; }
    }
}
