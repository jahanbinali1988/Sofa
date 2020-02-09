using System;

namespace Sofa.SharedKernel.Mongo.Entity
{
    public class PostMongo
    {
        public virtual Guid Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public short PostType { get; set; }
        public Guid CourseId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
