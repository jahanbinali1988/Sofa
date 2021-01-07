using Autofac;
using Microsoft.EntityFrameworkCore;
using Sofa.Identity.EntityFramework.Context;
using Sofa.Identity.repository.EF;
using Sofa.Identity.Repository;
using Sofa.Identity.Repository.Dapper;

namespace Sofa.Identity.DependencyInjection
{
    public class RegisterDBFactory : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SofaIdentityDbContext>().As<DbContext>();
            builder.RegisterType<EfUnitOfWork>().As<IEfUnitOfWork>();

            builder.RegisterType<DapperUnitOfWork>().As<IDapperUnitOfWork>();
        }
    }
}
