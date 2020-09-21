using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class AddInstituteResponse : ResponseBase
    {
        public Guid NewRecordedId { get; set; }
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
}
