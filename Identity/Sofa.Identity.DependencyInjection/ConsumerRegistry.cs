using MassTransit;
using Sofa.Events.User;
using Sofa.Identiity.Consumer;
using Sofa.Identiity.Consumer.RegisterUser;
using Sofa.SharedKernel.BaseClasses.Bus;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

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
