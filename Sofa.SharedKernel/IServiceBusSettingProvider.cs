using Microsoft.Extensions.Configuration;

namespace Sofa.SharedKernel
{
    public interface IServiceBusSettingProvider
    {
        BusSetting GetBusSetting();
    }
}
