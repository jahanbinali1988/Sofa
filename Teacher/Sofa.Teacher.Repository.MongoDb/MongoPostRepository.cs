using MongoDB.Bson;
using MongoDB.Driver;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Mongo.Entity;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository.MongoDb.Mapper;
using System;
using System.Collections.Generic;

namespace Sofa.Teacher.Repository.MongoDb
{
    public class MongoPostRepository : IPostMongoRepository
    {

        private IMongoClient mongoClient;
        private ILogger logger;
        readonly IMongoDbSettingsProvider mongoDbSettingsProvider;

        public MongoPostRepository(IMongoClient mongoClient, ILogger logger,
            IMongoDbSettingsProvider mongoDbSettingsProvider)
        {
            this.mongoDbSettingsProvider = mongoDbSettingsProvider;
            this.logger = logger;
            this.mongoClient = mongoClient;
        }

        public Post GetPostById(Guid postId)
        {
            var settings = mongoDbSettingsProvider.GetSettings();
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            var collection = database.GetCollection<BsonDocument>(settings.AssetStatusTableName);

            var projection = Builders<BsonDocument>
                                 .Projection.Include("Id").Include("Title").Include("Order")
                                 .Include("PostType").Include("CourseId").Include("Description")
                                 .Include("IsActive").Exclude("_id");

            var filter = Builders<BsonDocument>.Filter.Eq("Id", postId);
            var response = collection.Find<BsonDocument>(filter).Project<PostMongo>(projection).Limit(1);
            if (response.CountDocuments() <= 0)
                return Post.CreateInstance();

            return response.First<PostMongo>().ToEntity();
        }

        public IEnumerable<Guid> GetPostCollectionByCourseId(Guid courseId)
        {
            var settings = mongoDbSettingsProvider.GetSettings();
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            var collection = database.GetCollection<BsonDocument>(settings.AssetStatusTableName);

            var projection = Builders<BsonDocument>
                                 .Projection.Include("Id").Exclude("_id");

            var filter = Builders<BsonDocument>.Filter.Eq("CourseId", courseId);
            var response = collection.Find<BsonDocument>(filter).Project<Guid>(projection).Limit(1);

            if (response.CountDocuments() <= 0)
                return new List<Guid>();

            return response.ToList<Guid>();
        }
    }
}
