using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.Teacher.Model
{
    public class Post : BaseEntity
    {
        public string Title { get; internal set; }
        public short Order { get; internal set; }
        public string Content { get; internal set; }
        public ContentTypeEnum PostType { get; internal set; }
        public Guid LessonPlanId { get; internal set; }
        public LessonPlan LessonPlan { get; internal set; }

        internal Post()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignOrder(short order) { this.Order = order; }
        public void AssignContent(string content) { this.Content = content; }
        public void AssignPostType(ContentTypeEnum contentType) { this.PostType = contentType; }
        public void AssignLessonPlan(Guid lessonplanId) { this.LessonPlanId = lessonplanId; }
        public void AssignLessonPlan(LessonPlan lessonPlan) { this.LessonPlan = lessonPlan; }
        public static Post CreateInstance()
        {
            return new Post();
        }

        public static Post CreateInstance(Guid? id, bool isActive, string description)
        {
            var post = new Post()
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid()
            };
            post.AssignCreateDate(DateTime.Now);
            post.AssignFirstRowVersion();
            post.AssignIsActive(isActive);
            post.AssignIsDeleted(false);
            post.AssignDescription(description);

            return post;
        }
        public static Post CreateInstance(Guid? id, string title, short order, ContentTypeEnum postType, string content, Guid lessonplanId, string description, bool isActive)
        {
            return new Post()
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                Title = title,
                Order = order,
                Content = content,
                PostType = postType,
                LessonPlanId = lessonplanId,
                IsActive = isActive,
                Description = description,
                RowVersion = 0,
                IsDeleted = false,
                CreateDate = DateTime.Now
            };
        }
    }
}
