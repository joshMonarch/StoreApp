namespace Store.Application.Abstractions.Commons
{
    public interface IReadRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync(CancellationToken ct);
        Task<T> GetByIdAsync(int id, CancellationToken ct);
    }
}
