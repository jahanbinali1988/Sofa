using Autofac;
using Sofa.CourseManagement.DomainService;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterDomainServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InstituteDomainService>().As<IInstituteDomainService>();
            builder.RegisterType<FieldDomainService>().As<IFieldDomainService>();
            builder.RegisterType<CourseDomainService>().As<ICourseDomainService>();
            builder.RegisterType<TermDomainService>().As<ITermDomainService>();
            builder.RegisterType<SessionDomainService>().As<ISessionDomainService>();
            builder.RegisterType<LessonPlanDomainService>().As<ILessonPlanDomainService>();
            builder.RegisterType<PostDomainService>().As<IPostDomainService>();
            builder.RegisterType<UserDomainService>().As<IUserDomainService>();
        }
    }
}
