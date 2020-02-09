using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sofa.Teacher.ApplicationService
{
    public class ExistedUserResponse : ResponseBase
    {
        public ExistedUserResponse(bool existed) : base(true, "")
        {
            Existed = existed;
        }

        public ExistedUserResponse(bool successful, string message, string errorMessage) : base(successful, message, errorMessage)
        {
        }

        public ExistedUserResponse(bool successful, string message) : base(successful, message, "")
        {
        }

        public bool Existed { get; set; }
    }
}
