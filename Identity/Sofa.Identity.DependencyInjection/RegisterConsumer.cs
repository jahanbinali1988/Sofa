using Autofac;
using MassTransit;
using Sofa.Events.User;
using Sofa.Identiity.Consumer.RegisterUser;

namespace Sofa.Identity.DependencyInjection
{
    public class RegisterConsumer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUserEventConsumer>().As<IConsumer<RegisteredUserEvent>>();
        }
    }
}
