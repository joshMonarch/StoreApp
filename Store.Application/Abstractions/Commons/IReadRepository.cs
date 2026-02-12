using Store.Domain.Commons;

namespace Store.Application.Abstractions.Commons
{
    public interface IReadRepository<T>
    {
        Task<Result<T>> GetAllAsync(CancellationToken ct);
        Task<Result<T>> GetByIdAsync(int id, CancellationToken ct);
    }
}
