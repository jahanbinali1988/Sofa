using Autofac;
using System.Collections.Generic;

namespace Sofa.Identity.DependencyInjection
{
    public static class RegisterProvider
    {
        public static IList<Module> GetAllRegistry()
        {
            var result = new List<Module>
            {
                new RegisterDBFactory(),

                new RegisterRepository(),
                new RegisterRepository(),

                new RegisterConsumer()
        };

            return result;
        }
    }
}
