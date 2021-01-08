using Microsoft.Extensions.Configuration;
using Sofa.SharedKernel;

namespace Sofa.CourseManagement.WebApi
{
    public class ServiceBusSettingProvider : IServiceBusSettingProvider
    {
        private IConfiguration configuration;

        public ServiceBusSettingProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        BusSetting IServiceBusSettingProvider.GetBusSetting()
        {
            return configuration.GetSection("BusSetting").Get<BusSetting>();
        }
    }
}
