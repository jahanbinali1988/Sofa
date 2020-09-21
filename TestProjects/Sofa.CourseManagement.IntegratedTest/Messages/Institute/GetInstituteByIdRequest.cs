using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.CourseManagement.IntegratedTest.Messages
{
    public class GetInstituteByIdRequest : RequestBase
    {
        public Guid Id { get; set; }
    }
}
