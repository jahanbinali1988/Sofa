using Sofa.Identity.repository.EF;
using Sofa.Identity.Repository;
using Sofa.Identity.Repository.Dapper;
using StructureMap;

namespace Sofa.Identity.DependencyInjection
{
    public class IdentityRepositoryRegistry : Registry
    {
        public IdentityRepositoryRegistry()
        {
            For<IEfUserRepository>().Use<EfUserRepository>().ContainerScoped();
            For<IDapperUserRepository>().Use<DapperUserRepository>().ContainerScoped();
        }
    }
}
