using Sofa.Identity.ApplicationService;
using StructureMap;

namespace Sofa.Identity.DependencyInjection
{
    public class IdentityServiceRegistry : Registry
    {
        public IdentityServiceRegistry()
        {
            For<IAuthenticationService>().Use<AuthenticationService>().ContainerScoped();
        }
    }
}
