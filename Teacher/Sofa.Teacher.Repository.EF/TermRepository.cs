using Sofa.EntityFramework.Repository;
using Sofa.Teacher.EntityFramework.Context;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository.EF
{
    public class TermRepository : EfRepositoryBase<Term, Guid>, ITermRepository
    {
        private readonly ApplicationDbContext _context;
        public TermRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
