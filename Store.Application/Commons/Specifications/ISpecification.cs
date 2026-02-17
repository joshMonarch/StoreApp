using System.Linq.Expressions;

namespace Store.Application.Commons.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>>? Condition { get; }
    }
}
