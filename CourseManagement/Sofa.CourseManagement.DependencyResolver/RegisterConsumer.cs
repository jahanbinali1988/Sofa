using MassTransit;
using Autofac;
using System;
using System.Threading.Tasks;
using Sofa.Events.User;
using Sofa.CourseManagement.Consumer.RegisterUser;

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
