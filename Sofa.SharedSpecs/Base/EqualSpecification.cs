using System;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public class EqualSpecification<T> : ISpecification<T>, IEqualSpecification<T>
    {
        private readonly Specification<T> _spec1;
        private readonly Specification<T> _spec2;
        private readonly bool _equality;
        public EqualSpecification(Specification<T> spec1, Specification<T> spec2, bool equality)
        {
            this._spec1 = spec1;
            this._spec2 = spec2;
            this._equality = equality;
        }

        public ISpecification<T> Spec1 => _spec1;
        public ISpecification<T> Spec2 => _spec2;
        public bool Equality => _equality;
        public bool IsSatisfiedBy(T candidate)
        {
            var predicate = ToExpression().Compile();
            return predicate(candidate);
        }
        public Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _spec2.ToExpression();
            Expression<Func<T, bool>> rightExpression = _spec1.ToExpression();
            BinaryExpression equalExpression = null;

            if (Equality)
                equalExpression = Expression.Equal(leftExpression, rightExpression);
            else
                equalExpression = Expression.NotEqual(leftExpression, rightExpression);

            return Expression.Lambda<Func<T, bool>>(equalExpression);
        }
    }

    internal interface IEqualSpecification<T> : ISpecification<T>
    {
        ISpecification<T> Spec1 { get; }
        ISpecification<T> Spec2 { get; }
        bool Equality { get; }
    }
}
