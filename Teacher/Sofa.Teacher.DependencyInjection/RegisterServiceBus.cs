using Autofac;
using MassTransit;
using Sofa.SharedKernel;
using Sofa.Teacher.Consumer.RegisterLessonPlan;
using Sofa.Teacher.Consumer.RegisterUser;
using Sofa.Teacher.Consumer.ReisterPost;
using Sofa.Teacher.Repository;

namespace Sofa.Teacher.DependencyResolver
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
                    cfg.Host(busSettings.HostAddress, h =>
                    {
                        h.Username(busSettings.Username);
                        h.Password(busSettings.Password);
                    });

                    cfg.ReceiveEndpoint(busSettings.QueueName, x =>
                    {
                        x.Instance(new RegisterUserEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        x.Instance(new RegisterLessonPlanEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
                        x.Instance(new ReisterPostEventConsumer(context.Resolve<IUnitOfWork>(), context.Resolve<ILogger>()));
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
