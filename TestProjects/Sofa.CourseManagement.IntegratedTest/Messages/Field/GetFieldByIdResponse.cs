using Sofa.CourseManagement.ApplicationService;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
   public class GetFieldByIdResponse : ResponseBase
    {
        public FieldDto Field { get; set; }
    }
}
