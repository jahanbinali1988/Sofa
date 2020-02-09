using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest
{
    public class AddLevelResponse : ResponseBase
    {
        public Guid NewRecordedId { get; set; }
        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }
}
