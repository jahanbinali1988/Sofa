using Autofac;
using Sofa.CourseManagement.DomainService;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterDomainServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LessonPlanDomainService>().As<ILessonPlanDomainService>();
            builder.RegisterType<LessonDomainService>().As<ILessonDomainService>();
            builder.RegisterType<PostDomainService>().As<IPostDomainService>();
            builder.RegisterType<UserDomainService>().As<IUserDomainService>();
        }
    }
}
