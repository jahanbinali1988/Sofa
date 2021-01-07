using Autofac;
using Sofa.Identity.ApplicationService;

namespace Sofa.Identity.DependencyInjection
{
    public class RegisterService : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<ProfileService>().As<IProfileService>();
        }
    }
}
