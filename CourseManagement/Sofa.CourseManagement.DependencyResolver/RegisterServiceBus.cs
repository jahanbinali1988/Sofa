using Autofac;
using MassTransit;
using Sofa.SharedKernel;
using System;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterServiceBus : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<IBusControl>(context =>
            {
                var busSettingProvider = context.Resolve<IServiceBusSettingProvider>();
                var busSettings = busSettingProvider.GetBusSetting();

                var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(busSettings.Scheme + "://" + busSettings.HostAddress), busSettings.Port, h =>
                    {
                        h.Username(busSettings.Username);
                        h.Password(busSettings.Password);
                    });

                    cfg.ReceiveEndpoint(busSettings.QueueName, ec =>
                    {
                        ec.LoadFrom(context);
                    });
                });

                return busControl;
            })
                .SingleInstance()
                .As<IBusControl>()
                .As<IBus>();
        }
    }
}
