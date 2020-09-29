using Newtonsoft.Json;
using System;

namespace Sofa.SharedKernel.BaseClasses.Message
{
    public abstract class LoginRequiredRequest : RequestBase
    {
        [JsonIgnore]
        public Guid CommanderID { get; set; }
    }
}
