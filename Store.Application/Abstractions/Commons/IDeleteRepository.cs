using Store.Domain.Commons;

namespace Store.Application.Abstractions.Commons
{
    public interface IDeleteRepository<T>
    {
        Task<Result<int>> DeleteAsync(T entity, CancellationToken ct);
    }
}
