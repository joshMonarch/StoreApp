using Store.Application.Commons.Specifications;
using System.Collections.ObjectModel;

namespace Store.Application.Abstractions.Commons
{
    public interface IReadRepository<T>
    {
        Task<ReadOnlyCollection<T>> GetAllAsync(CancellationToken ct);
        Task<ReadOnlyCollection<T>> GetFilteredAsync(ISpecification<T> spec, CancellationToken ct);
        Task<T> GetByIdAsync(int id, CancellationToken ct);
    }
}
