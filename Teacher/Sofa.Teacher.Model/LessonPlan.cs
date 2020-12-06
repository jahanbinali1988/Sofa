using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Sofa.Teacher.Model
{
    public class LessonPlan : BaseEntity
    {
        public LevelEnum Level { get; internal set; }

        public Guid SessionId { get; internal set; }
        [NotMapped]
        public Session Session { get; internal set; }
        public ICollection<Post> Posts { get; internal set; }

        internal LessonPlan()
        {

        }

        public void AssignLevel(LevelEnum level) { this.Level = level; }
        public void AssignLevel(short level) { this.Level = (LevelEnum)level; }
        public void AssignSession(Guid sessionId) { this.SessionId = sessionId; }
        public void AssignSession(Session session) { this.SessionId = session.Id; this.Session = session; }
        public void AssignPosts(IEnumerable<Post> posts)
        {
            if (this.Posts.Any())
                this.Posts.ToList().AddRange(posts);
            else
                this.Posts = posts.ToArray();
        }

        public static LessonPlan CreateInstance(Guid? id, bool isActive, string description)
        {
            var lessonPlan = new LessonPlan();
            lessonPlan.Id = id.HasValue ? id.Value : Guid.Empty;
            lessonPlan.AssignCreateDate(DateTime.Now);
            lessonPlan.AssignFirstRowVersion();
            lessonPlan.AssignIsActive(isActive);
            lessonPlan.AssignIsDeleted(false);
            lessonPlan.AssignDescription(description);

            return lessonPlan;
        }
        public static LessonPlan CreateInstance(Guid? id, LevelEnum level, Guid sessionId, bool isAvtive, string description)
        {
            var lessonPlan = CreateInstance(id, isAvtive, description);
            lessonPlan.AssignSession(sessionId);
            lessonPlan.AssignLevel(level);

            return lessonPlan;
        }
        public static LessonPlan CreateInstance(Guid? id, short level, Guid sessionId, bool isAvtive, string description)
        {
            var lessonPlan = CreateInstance(id, isAvtive, description);
            lessonPlan.AssignSession(sessionId);
            lessonPlan.AssignLevel(level);

            return lessonPlan;
        }
    }
}
