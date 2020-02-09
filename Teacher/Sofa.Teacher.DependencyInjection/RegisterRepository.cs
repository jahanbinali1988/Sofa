using Autofac;
using Sofa.Teacher.Repository;
using Sofa.Teacher.Repository.EF;
using Sofa.Teacher.Repository.MongoDb;

namespace Sofa.Teacher.DependencyResolver
{
    public class RegisterRepository : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SyllabusRepository>().As<ISyllabusRepository>();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>();
            builder.RegisterType<MongoPostRepository>().As<IPostMongoRepository>();
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
