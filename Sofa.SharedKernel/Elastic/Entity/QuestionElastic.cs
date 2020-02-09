using System;
using System.Collections.Generic;

namespace Sofa.SharedKernel.Elastic.Entity
{
    public class QuestionElastic
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short Order { get; set; }
        public IEnumerable<AnswerElastic> Answers { get; set; }
        public Guid TrueAnswerId { get; set; }
        public Guid QuizId { get; set; }
    }
}
