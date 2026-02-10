namespace Store.Application.Abstractions.Commons
{
    public interface IReadRepository<T>
    {
        Task<T> GetAllAsync(CancellationToken ct);
        Task<T> GetByIdAsync(int id, CancellationToken ct);
    }
}
