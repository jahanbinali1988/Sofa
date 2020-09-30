using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.Teacher.Model
{
    public class Post : BaseEntity
    {
        public string Title { get; internal set; }
        public short Order { get; internal set; }
        public string PostContent { get; internal set; }
        public ContentTypeEnum PostType { get; internal set; }
        public Guid CourseId { get; internal set; }

        public Course Course { get; internal set; }

        internal Post()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignOrder(short order) { this.Order = order; }
        public void AssignPostContent(string content) { this.PostContent = content; }
        public void AssignPostType(ContentTypeEnum contentType) { this.PostType = contentType; }
        public void AssignCourse(Guid courseId) { this.CourseId = courseId; }
        public void AssignCourse(Course course) { this.Course = course; }
        public static Post CreateInstance()
        {
            return new Post();
        }
        public static Post CreateInstance(Guid? id, string title, short order, ContentTypeEnum postType, string postContent, Guid courseId, string description, bool isActive)
        {
            return new Post()
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                Title = title,
                Order = order,
                PostContent = postContent,
                PostType = postType,
                CourseId = courseId,
                IsActive = isActive,
                Description = description,
                RowVersion = 0,
                IsDeleted = false,
                CreateDate = DateTime.Now
            };
        }
    }
}
