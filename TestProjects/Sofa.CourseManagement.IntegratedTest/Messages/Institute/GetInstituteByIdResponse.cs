using Sofa.CourseManagement.Model;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetInstituteByIdResponse : ResponseBase
    {
        public Institute Institute { get; set; }
    }
}
