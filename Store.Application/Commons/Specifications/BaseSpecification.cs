using System.Linq.Expressions;

namespace Store.Application.Commons.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>>? Condition { get; protected set; }
    }
}
