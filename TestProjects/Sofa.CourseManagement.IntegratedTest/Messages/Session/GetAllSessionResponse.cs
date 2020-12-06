using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetAllSessionResponse : ResponseBase
    {
        public IEnumerable<SessionDto> Sessions { get; set; }
    }
}
