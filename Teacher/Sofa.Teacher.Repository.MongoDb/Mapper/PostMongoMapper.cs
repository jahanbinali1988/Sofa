using Sofa.SharedKernel.Enum;
using Sofa.SharedKernel.Mongo.Entity;
using Sofa.Teacher.Model;
using System.Collections.Generic;

namespace Sofa.Teacher.Repository.MongoDb.Mapper
{
    public static class PostMongoMapper
    {
        public static Post ToEntity(this PostMongo postMongo)
        {
            return new Post
            {
                Description = postMongo.Description,
                Id = postMongo.Id,
                IsActive = postMongo.IsActive,
                CourseId = postMongo.CourseId,
                Order = postMongo.Order,
                PostType = (PostTypeEnum)postMongo.PostType,
                Title = postMongo.Title
            };
        }

        public static IList<Post> ToEntity(this IEnumerable<PostMongo> postMongos)
        {
            var result = new List<Post>();

            foreach (var postMongo in postMongos)
            {
                var tmp = postMongo.ToEntity();
                result.Add(tmp);
            }

            return result;
        }
    }
}
