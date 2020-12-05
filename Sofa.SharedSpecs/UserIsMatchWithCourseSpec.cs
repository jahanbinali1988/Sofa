using Sofa.Identity.Model;
using System;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public class UserIsMatchWithCourseSpec : Specification<User>
    {
        readonly Guid targetSyllabusId;
        readonly Guid targetCourseId;

        public UserIsMatchWithCourseSpec(Guid SyllabusId, Guid courseId)
        {
            this.targetSyllabusId = SyllabusId;
            this.targetCourseId = courseId;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return x => x.UserCurrentCourseId == targetCourseId && x.UserCurrentSyllabusId == targetSyllabusId;
        }
    }
}
