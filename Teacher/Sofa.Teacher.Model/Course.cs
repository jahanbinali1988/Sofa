using Sofa.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.Teacher.Model
{
    public class Course : BaseEntity
    {
        public string Title { get; internal set; }
        public short Order { get; internal set; }
        public Guid SyllabusId { get; internal set; }

        public ICollection<Post> Posts { get; internal set; }
        public Syllabus Syllabus { get; internal set; }

        internal Course()
        {

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignOrder(short order) { this.Order = order; }
        public void AssignSyllabus(Guid syllabusId) { this.SyllabusId = syllabusId; }
        public void AssignSyllabus(Syllabus syllabus) { this.SyllabusId = syllabus.Id; this.Syllabus = syllabus; }
        public void AssignPost(IEnumerable<Post> posts) 
        {
            if (Posts.Any())
                this.Posts.ToList().AddRange(posts);
            else
                this.Posts = posts.ToArray();
        }
        public static Course CreateInstance(Guid? id, string title, short order, Guid syllabusId, string description, bool isActive)
        {
            return new Course()
            {
                Id = id.HasValue ? id.Value : Guid.NewGuid(),
                Title = title,
                Order = order,
                SyllabusId = syllabusId,
                CreateDate = DateTime.Now,
                Description = description,
                IsActive = isActive,
                RowVersion = 1,
                IsDeleted = false
            };
        }
    }
}
