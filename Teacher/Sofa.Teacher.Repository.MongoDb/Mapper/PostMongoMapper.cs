using Sofa.SharedKernel.Mongo.Entity;
using Sofa.Teacher.Model;
using System.Collections.Generic;

namespace Sofa.Teacher.Repository.MongoDb.Mapper
{
    public static class PostMongoMapper
    {
        public static Post ToEntity(this PostMongo postMongo)
        {
            Post post = Post.CreateInstance(postMongo.Id, postMongo.Title, postMongo.Order, postMongo.PostType, postMongo.PostContent, postMongo.CourseId, postMongo.Description, postMongo.IsActive);
            return post;
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
