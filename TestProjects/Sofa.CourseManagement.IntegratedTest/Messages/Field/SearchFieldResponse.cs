using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class SearchFieldResponse : ResponseBase
    {
        public IEnumerable<FieldDto> Fields { get; set; }
    }
}
