using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetAllTermResponse : ResponseBase
    {
        public IEnumerable<TermDto> Terms { get; set; }
    }
}
