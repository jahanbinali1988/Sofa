using Sofa.SharedKernel.BaseClasses;
using System;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public class EntityIsDisableSpec<TEntity> : Specification<TEntity> where TEntity:BaseEntity
    {
        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            return e => !e.IsActive;
        }
    }
}
