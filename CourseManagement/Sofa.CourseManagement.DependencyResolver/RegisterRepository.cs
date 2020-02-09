using Autofac;
using Sofa.CourseManagement.Repository;
using Sofa.CourseManagement.Repository.EF;

namespace Sofa.CourseManagement.DependencyResolver
{
    public class RegisterRepository : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LessonPlanRepository>().As<ILessonPlanRepository>();
            builder.RegisterType<LessonRepository>().As<ILessonRepository>();
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
