using Sofa.SharedKernel.BaseClasses;

namespace Sofa.SharedKernel
{
    public interface IMongoDbSettingsProvider
    {
        MongoDbSettings GetSettings();
    }
}
