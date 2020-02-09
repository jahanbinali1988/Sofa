using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public interface IOrSpecification<T> : ISpecification<T>
    {
        ISpecification<T> Spec1 { get; }
        ISpecification<T> Spec2 { get; }
    }

    public sealed class OrSpecification<T> : ISpecification<T>, IOrSpecification<T>
    {
        private readonly Specification<T> _spec1;
        private readonly Specification<T> _spec2;

        public OrSpecification(Specification<T> Spec1, Specification<T> spec2)
        {
            _spec2 = spec2;
            _spec1 = Spec1;
        }

        ISpecification<T> IOrSpecification<T>.Spec1 =>  _spec1;
        ISpecification<T> IOrSpecification<T>.Spec2 => _spec2;
        public Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _spec2.ToExpression();
            Expression<Func<T, bool>> rightExpression = _spec1.ToExpression();

            BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);

            return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters.Single());
        }
        public bool IsSatisfiedBy(T candidate)
        {
            var predicate = ToExpression().Compile();
            return predicate(candidate);
        }
    }
}
