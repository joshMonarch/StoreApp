namespace Store.Application.Abstractions.Commons
{
    public interface ICreateRepository<T>
    {
        Task<int> CreateAsync(T entity, CancellationToken ct);
    }
}
