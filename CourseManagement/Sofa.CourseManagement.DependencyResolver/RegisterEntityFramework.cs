using Autofac;
using Sofa.CourseManagement.Repository;
using Sofa.CourseManagement.Repository.EF;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterEntityFramework : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
