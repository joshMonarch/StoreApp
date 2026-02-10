namespace Store.Application.Abstractions.Commons
{
    public interface IUpdateRepository<T>
    {
        Task<int> UpdateAsync(T entity, CancellationToken ct);
    }
}
