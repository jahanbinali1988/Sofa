using Microsoft.EntityFrameworkCore;
using Sofa.Identity.EntityFramework.Context;
using Sofa.Identity.repository.EF;
using Sofa.Identity.Repository;
using Sofa.Identity.Repository.Dapper;
using StructureMap;

namespace Sofa.Identity.DependencyInjection
{
    public class DBFactoryRegistry : Registry
    {
        public DBFactoryRegistry()
        {
            For<DbContext>().Use<SofaIdentityDbContext>().ContainerScoped();
            For<IEfUnitOfWork>().Use<EfUnitOfWork>().ContainerScoped();

            For<IDapperUnitOfWork>().Use<DapperUnitOfWork>().ContainerScoped();
        }
    }
}
