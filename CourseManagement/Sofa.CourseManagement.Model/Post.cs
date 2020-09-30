using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.Model
{
    public class Post : BaseEntity
    {
        public string Title { get; internal set; }
        public short Order { get; internal set; }
        public string Content { get; internal set; }
        public ContentTypeEnum ContentType { get; internal set; }

        public Guid LessonPlanId { get; internal set; }
        public LessonPlan LessonPlan { get; internal set; }

        internal Post()
        {

        }

        public void AssignContent(string content) { Content = content; }
        public void AssignContentType(ContentTypeEnum contentType) { ContentType = contentType; }
        public void AssignOrder(short order) { Order = order; }
        public void AssignTitle(string title) { Title = title; }
        public void AssignLessonPlan(Guid lessonPlanId) { LessonPlanId = lessonPlanId; }
        public void AssignLessonPlan(LessonPlan lessonPlan) { LessonPlanId = lessonPlan.Id; LessonPlan = lessonPlan; }
        public static Post CreateInstance(Guid? id, string title, short order, ContentTypeEnum contentType, string content, Guid LessonPlanId, bool isActive, string description)
        {
            return new Post()
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                Title = title,
                Order = order,
                ContentType = contentType,
                Content = content,
                LessonPlanId = LessonPlanId,
                IsActive = isActive,
                RowVersion = 0,
                CreateDate = DateTime.Now,
                IsDeleted = false,
                Description = description
            };
        }
    }
}
