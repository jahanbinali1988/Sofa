using Microsoft.Extensions.Configuration;
using Sofa.SharedKernel;

namespace Sofa.Web
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
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
