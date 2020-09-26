using Autofac;
using Sofa.CourseManagement.ApplicationService;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InstituteService>().As<IInstituteService>();
            builder.RegisterType<FieldService>().As<IFieldService>();
            builder.RegisterType<CourseService>().As<ICourseService>();
            builder.RegisterType<TermService>().As<ITermService>();
            builder.RegisterType<SessionService>().As<ISessionService>();
            builder.RegisterType<LessonPlanService>().As<ILessonPlanService>();
            builder.RegisterType<PostService>().As<IPostService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
