namespace Store.Application.Abstractions.Commons
{
    public interface IDeleteRepository<T>
    {
        Task<int> DeleteAsync(T entity, CancellationToken ct);
    }
}
