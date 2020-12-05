using System;
using System.Linq.Expressions;

namespace Sofa.SharedSpecs
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }

        public static NotSpecification<T> operator !(Specification<T> spec)
        {
            return spec.Not();
        }
        public static AndSpecification<T> operator &(Specification<T> spec1, Specification<T> spec2)
        {
            return spec1.And(spec2);
        }
        public static OrSpecification<T> operator |(Specification<T> spec1, Specification<T> spec2)
        {
            return spec1.Or(spec2);
        }
        public static EqualSpecification<T> operator ==(Specification<T> spec1, Specification<T> spec2)
        {
            return spec1.Equal(spec2);
        }
        public static EqualSpecification<T> operator !=(Specification<T> spec1, Specification<T> spec2)
        {
            return spec1.NotEqual(spec2);
        }


        public AndSpecification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
        public OrSpecification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }
        public NotSpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
        public EqualSpecification<T> NotEqual(Specification<T> specification)
        {
            return new EqualSpecification<T>(this, specification, true);
        }
        public EqualSpecification<T> Equal(Specification<T> specification)
        {
            return new EqualSpecification<T>(this, specification, false);
        }
    }
}
