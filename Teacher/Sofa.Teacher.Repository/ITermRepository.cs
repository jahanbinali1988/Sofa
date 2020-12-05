using Sofa.EntityFramework.Repository;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository
{
    public interface ITermRepository : IEfRepositoryBase<Term, Guid>
    {
    }
}
