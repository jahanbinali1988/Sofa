using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public interface INotSpecification<T> : ISpecification<T>
    {
        ISpecification<T> Inner { get; }
    }

    public sealed class NotSpecification<T> : ISpecification<T>, INotSpecification<T>
    {
        public Specification<T> _inner { get; }
        public NotSpecification(Specification<T> inner)
        {
            _inner = inner;
        }

        public ISpecification<T> Inner => _inner;
        public Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> inner = _inner.ToExpression();

            UnaryExpression notExpression = Expression.Not(inner.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, inner.Parameters.Single());
        }
        public bool IsSatisfiedBy(T candidate)
        {
            var predicate = ToExpression().Compile();
            return predicate(candidate);
        }
    }
}
