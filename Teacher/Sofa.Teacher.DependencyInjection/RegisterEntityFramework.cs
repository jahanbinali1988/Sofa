using Autofac;
using Sofa.Teacher.Repository;
using Sofa.Teacher.Repository.EF;

namespace Sofa.Teacher.DependencyResolver
{
    public class RegisterEntityFramework : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
