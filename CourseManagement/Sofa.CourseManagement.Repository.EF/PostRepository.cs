﻿using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.EntityFramework.Context;
using Sofa.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sofa.CourseManagement.Repository.EF
{
    public class PostRepository : EfRepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
