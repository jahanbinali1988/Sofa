using Sofa.SharedKernel.BaseClasses;
using System;

namespace Sofa.Teacher.ApplicationService
{
    public class GetUserByIdRequest : RequestBase
    {
        public Guid UserId { get; set; }
    }
}
