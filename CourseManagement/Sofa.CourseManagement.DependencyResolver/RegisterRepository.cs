using Autofac;
using Sofa.CourseManagement.Repository;
using Sofa.CourseManagement.Repository.EF;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterRepository : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InstituteRepository>().As<IInstituteRepository>();
            builder.RegisterType<LessonPlanRepository>().As<ILessonPlanRepository>();
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<FieldRepository>().As<IFieldRepository>();
            builder.RegisterType<TermRepository>().As<ITermRepository>();
            builder.RegisterType<SessionRepository>().As<ISessionRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
        }
    }
}
