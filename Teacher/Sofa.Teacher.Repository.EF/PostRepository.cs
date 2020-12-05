using Sofa.EntityFramework.Repository;
using Sofa.Teacher.EntityFramework.Context;
using Sofa.Teacher.Model;
using System;

namespace Sofa.Teacher.Repository.EF
{
    public class PostRepository : EfRepositoryBase<Post, Guid>, IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
