using System;
using System.Data;

namespace Sofa.Dapper
{
    public interface IDbFactory : IDisposable
    {
        IDbConnection Context();
        string IdentitySql();
        string PagingTemplate(int pageNumber, int rowsPerPage);
        string EncapsulationTemplate();
    }
}
