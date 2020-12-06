using Sofa.CourseManagement.ApplicationService;
using Sofa.CourseManagement.IntegratedTest.Utilities;
using System.Collections.Generic;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetAllInstituteResponse : ResponseBase
    {
        public IEnumerable<InstituteDto> Institutes { get; set; }
    }
}
