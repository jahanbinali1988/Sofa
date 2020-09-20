using Autofac;
using Sofa.CourseManagement.DomainService;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterDomainServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InstituteDomainService>().As<IInstituteDomainService>();
            builder.RegisterType<LessonPlanDomainService>().As<ILessonPlanDomainService>();
            builder.RegisterType<PostDomainService>().As<IPostDomainService>();
            builder.RegisterType<UserDomainService>().As<IUserDomainService>();
        }
    }
}
