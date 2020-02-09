using System;

namespace Sofa.SharedKernel.Elastic.Entity
{
    public class QuizElastic
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public Guid CourseId { get; set; }
    }
}
