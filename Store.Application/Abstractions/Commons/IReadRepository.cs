using MediatR;
using System.Collections.ObjectModel;

namespace Store.Application.Abstractions.Commons
{
    public interface IReadRepository<TDto, TRequest>
    {
        Task<ReadOnlyCollection<TDto>> GetAllAsync(CancellationToken ct);
        Task<ReadOnlyCollection<TDto>> GetFilteredAsync(TRequest request, CancellationToken ct);
        Task<TDto> GetByIdAsync(int id, CancellationToken ct);
    }
}
