using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.SharedKernel.Mongo.Entity
{
    public class PostMongo
    {
        public virtual Guid Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public ContentTypeEnum PostType { get; set; }
        public string PostContent { get; set; }
        public Guid CourseId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        internal PostMongo()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignOrder(short order) { this.Order = order; }
        public void AssignPostType(ContentTypeEnum contentType) { this.PostType = contentType; }
        public void AssignPostContent(string content) { this.PostContent = content; }
        public void AssignCourseId(Guid courseId) { this.CourseId = courseId; }
        public void AssignDescription(string description) { this.Description = description; }
        public void AssignisActive(bool isActive) { this.IsActive = isActive; }
        public static PostMongo CreateInstance(Guid? id, string title, string postContent, ContentTypeEnum postType, short order, Guid courseId, bool isActive, string description)
        {
            return new PostMongo()
            {
                CourseId = courseId,
                PostContent = postContent,
                Description = description,
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                IsActive = isActive,
                Order = order,
                PostType = postType,
                Title = title
            };
        }
    }
}
