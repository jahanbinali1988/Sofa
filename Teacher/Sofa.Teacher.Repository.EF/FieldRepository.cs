using Sofa.EntityFramework.Repository;
using Sofa.Teacher.EntityFramework.Context;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository.EF
{
    public class FieldRepository : EfRepositoryBase<Field, Guid>, IFieldRepository
    {
        private readonly ApplicationDbContext _context;
        public FieldRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
