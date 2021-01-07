using Autofac;
using Sofa.Identity.repository.EF;
using Sofa.Identity.Repository;
using Sofa.Identity.Repository.Dapper;

namespace Sofa.Identity.DependencyInjection
{
    public class RegisterRepository : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfUserRepository>().As<IEfUserRepository>();
            builder.RegisterType<DapperUserRepository>().As<IDapperUserRepository>();
        }
    }
}
