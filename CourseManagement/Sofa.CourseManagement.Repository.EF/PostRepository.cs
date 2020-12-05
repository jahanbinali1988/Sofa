using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;

namespace Sofa.CourseManagement.Repository.EF
{
    public class PostRepository : EfRepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
