using Microsoft.Extensions.Configuration;
using Sofa.SharedKernel;

namespace Sofa.Identity.WebAPI
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        readonly IConfiguration configuration;
        public ConnectionStringProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString()
        {
            string cs = configuration.GetConnectionString("SofaIdentity");
            return cs;
        }
    }
}
