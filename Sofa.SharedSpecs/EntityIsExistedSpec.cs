using System;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public class EntityIsExistedSpec<TEntity> : Specification<TEntity>
    {
        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            return e => e != null;
        }
    }
}
