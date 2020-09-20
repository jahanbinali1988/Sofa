using Sofa.SharedKernel;
using MassTransit;
using StructureMap;
using System;
using Sofa.Identiity.Consumer.RegisterUser;
using Sofa.Identity.Repository;
using Sofa.SharedKernel.Validation;

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
                    cfg.Host(
                        new Uri(busSetting.Scheme + "://" + busSetting.HostAddress), cfg =>
                        {
                            cfg.Username(busSetting.Username);
                            cfg.Password(busSetting.Password);
                        });

                    cfg.ReceiveEndpoint(busSetting.QueueName, e =>
                    {
                        //e.Bind(busSetting.QueueName, s => { s.Durable = true; });
                        //e.Instance(new RegisterUserEventConsumer(container.GetInstance<IEfUnitOfWork>(), container.GetInstance<ILogger>()));
                        //or
                        e.Consumer<RegisterUserEventConsumer>(container);
                    });
                });
            }).Singleton();
            Forward<IBusControl, IBus>();
        }
    }
}
