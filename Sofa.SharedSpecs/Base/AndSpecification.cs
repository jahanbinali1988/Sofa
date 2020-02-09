using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public interface IAndSpecification<T>
    {
        ISpecification<T> Spec1 { get; }
        ISpecification<T> Spec2 { get; }
    }

    public sealed class AndSpecification<T> : ISpecification<T>, IAndSpecification<T>
    {
        private readonly Specification<T> _spec1;
        private readonly Specification<T> _spec2;

        public AndSpecification(Specification<T> spec2, Specification<T> spec1)
        {
            _spec2 = spec2;
            _spec1 = spec1;
        }

        public ISpecification<T> Spec1 => _spec1;
        public ISpecification<T> Spec2 => _spec2;
        public Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _spec1.ToExpression();
            Expression<Func<T, bool>> rightExpression = _spec2.ToExpression();

            BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
        }
        public bool IsSatisfiedBy(T candidate)
        {
            var predicate = ToExpression().Compile();
            return predicate(candidate);
        }
    }
}
