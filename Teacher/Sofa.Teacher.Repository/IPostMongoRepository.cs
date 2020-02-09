using Sofa.Teacher.Model;
using System;
using System.Collections.Generic;

namespace Sofa.Teacher.Repository
{
    public interface IPostMongoRepository
    {
        IEnumerable<Guid> GetPostCollectionByCourseId(Guid courseId);
        Post GetPostById(Guid postId);
    }
}
