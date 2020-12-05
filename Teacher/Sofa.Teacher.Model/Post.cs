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
        public void AssignPostType(short contentType) { this.PostType = (ContentTypeEnum)contentType; }
        public void AssignLessonPlan(Guid lessonplanId) { this.LessonPlanId = lessonplanId; }
        public void AssignLessonPlan(LessonPlan lessonPlan) { this.LessonPlan = lessonPlan; }

        public static Post CreateInstance(Guid? id, bool isActive, string description)
        {
            var post = new Post();
            post.Id = id.HasValue ? id.Value : Guid.Empty;
            post.AssignCreateDate(DateTime.Now);
            post.AssignFirstRowVersion();
            post.AssignIsActive(isActive);
            post.AssignIsDeleted(false);
            post.AssignDescription(description);

            return post;
        }
        public static Post CreateInstance(Guid? id, string title, short order, ContentTypeEnum postType, string content, Guid lessonplanId, bool isActive, string description)
        {
            var post = CreateInstance(id, isActive, description);
            post.AssignTitle(title);
            post.AssignOrder(order);
            post.AssignPostType(postType);
            post.AssignContent(content);
            post.AssignLessonPlan(lessonplanId);

            return post;
        }
        public static Post CreateInstance(Guid? id, string title, short order, short postType, string content, Guid lessonplanId, bool isActive, string description)
        {
            var post = CreateInstance(id, isActive, description);
            post.AssignTitle(title);
            post.AssignOrder(order);
            post.AssignPostType(postType);
            post.AssignContent(content);
            post.AssignLessonPlan(lessonplanId);

            return post;
        }
    }
}
