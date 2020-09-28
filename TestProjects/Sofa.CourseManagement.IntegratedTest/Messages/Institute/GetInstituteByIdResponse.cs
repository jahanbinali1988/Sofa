using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetInstituteByIdResponse : ResponseBase
    {
        public InstituteDto Institute { get; set; }
    }
}
