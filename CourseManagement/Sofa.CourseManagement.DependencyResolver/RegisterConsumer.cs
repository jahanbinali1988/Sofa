using Autofac;
using MassTransit;
using Sofa.CourseManagement.Consumer.RegisterUser;
using Sofa.Events.User;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterConsumer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUserEventConsumer>().As<IConsumer<RegisteredUserEvent>>();
        }
    }

    //public class AddStudenConsumer : IConsumer<RegisteredUserEvent>
    //{
    //    Task IConsumer<RegisteredUserEvent>.Consume(ConsumeContext<RegisteredUserEvent> context)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
