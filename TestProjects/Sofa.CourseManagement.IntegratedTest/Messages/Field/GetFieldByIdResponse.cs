using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetFieldByIdResponse : ResponseBase
    {
        public FieldDto Field { get; set; }
    }
}
