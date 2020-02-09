using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sofa.CourseManagement.IntegratedTest
{
    public class AddUserResponse : ResponseBase
    {
        public Guid NewRecordedId { get; set; }
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
}
