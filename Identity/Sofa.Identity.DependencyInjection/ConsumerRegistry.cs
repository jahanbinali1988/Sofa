using MassTransit;
using Sofa.Events.User;
using Sofa.Identiity.Consumer.RegisterUser;
using StructureMap;

namespace Sofa.Identity.DependencyInjection
{
    public class ConsumerRegistry : Registry
    {
        public ConsumerRegistry()
        {
            For<IConsumer<RegisteredUserEvent>>().Use<RegisterUserEventConsumer>();
        }
    }
}
