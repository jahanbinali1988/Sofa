using System;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public interface ISpecification<T> 
    {
        Expression<Func<T, bool>> ToExpression();

        bool IsSatisfiedBy(T candidate);
    }
}
