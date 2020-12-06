using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class SearchSessionResponse : ResponseBase
    {
        public IEnumerable<SessionDto> Sessions { get; set; }
    }
}
