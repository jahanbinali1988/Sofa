using Microsoft.Extensions.Configuration;
using Sofa.SharedKernel;

namespace Sofa.CourseManagement.IntegratedTest
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;
        public ConnectionStringProvider(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
