using Microsoft.Extensions.Configuration;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses;

namespace Sofa.Teacher.Bot
{
    public class MongoDbSettingsProvider : IMongoDbSettingsProvider
    {
        private IConfiguration configuration;

        public MongoDbSettingsProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public MongoDbSettings GetSettings()
        {
            return configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
        }
    }
}
