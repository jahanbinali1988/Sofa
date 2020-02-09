using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.Teacher.Model
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public short Order { get; set; }
        public PostTypeEnum PostType { get; set; }
        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public static Post DefaultFactory(string title, short order, PostTypeEnum postType, Guid courseId)
        {
            return new Post()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Order = order,
                PostType = postType,
                CourseId = courseId
            };
        }
    }
}
