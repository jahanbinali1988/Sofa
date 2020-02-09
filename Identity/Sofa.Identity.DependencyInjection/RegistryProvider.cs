using Sofa.SharedKernel;
using StructureMap;
using System.Collections.Generic;

namespace Sofa.Identity.DependencyInjection
{
    public static class RegistryProvider
    {
        public static IList<Registry> GetAllRegistry()
        {
            var result = new List<Registry>
            {
                new DBFactoryRegistry(),

                new IdentityRepositoryRegistry(),
                new IdentityServiceRegistry(),

                new ConsumerRegistry()
        };

            return result;
        }
    }
}
