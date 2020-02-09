using Sofa.SharedKernel;
using MassTransit;
using StructureMap;
using System;
using Sofa.Identiity.Consumer.RegisterUser;
using Sofa.Identity.Repository;

namespace Sofa.Identity.DependencyInjection
{
    public class ServiceBusRegistry : Registry
    {
        [Obsolete]
        public ServiceBusRegistry(IServiceBusSettingProvider provider, Container container)
        {
            var busSetting = provider.GetBusSetting();

            For<IBusControl>().Use("", () =>
            {
                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var host = cfg.Host(new Uri(busSetting.Scheme + "://" + busSetting.HostAddress), rabbitMqSetting =>
                    {
                        rabbitMqSetting.Username(busSetting.Username);
                        rabbitMqSetting.Password(busSetting.Password);
                    });

                    cfg.ReceiveEndpoint(host, busSetting.QueueName, e =>
                    {
                        e.Bind(busSetting.QueueName, s => { s.Durable = true; });
                        e.Instance(new RegisterUserEventConsumer(container.GetInstance<IEfUnitOfWork>(), container.GetInstance<ILogger>()));
                        //or
                        //e.Consumer<RegisterUserEventConsumer>(container);
                    });
                });
            }).Singleton();
            Forward<IBusControl, IBus>();
        }
    }
}
