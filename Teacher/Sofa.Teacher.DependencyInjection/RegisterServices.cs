using Autofac;
using Sofa.Teacher.ApplicationService.Service;

namespace Sofa.Teacher.DependencyResolver
{
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
