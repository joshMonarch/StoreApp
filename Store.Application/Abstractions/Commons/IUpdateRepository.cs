using Store.Domain.Commons;

namespace Store.Application.Abstractions.Commons
{
    public interface IUpdateRepository<T>
    {
        Task<Result<int>> UpdateAsync(T entity, CancellationToken ct);
    }
}
