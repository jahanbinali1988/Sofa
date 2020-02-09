using Autofac;
using Sofa.Teacher.DomainService;

namespace Sofa.Teacher.DependencyResolver
{
    public class RegisterDomainServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserDomainService>().As<IUserDomainService>();
        }
    }
}
