using Autofac;
using Sofa.CourseManagement.ApplicationService;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InstituteService>().As<IInstituteService>();
            builder.RegisterType<LessonPlanService>().As<ILessonPlanService>();
            builder.RegisterType<PostService>().As<IPostService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
