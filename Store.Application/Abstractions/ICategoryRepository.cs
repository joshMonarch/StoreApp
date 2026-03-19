using Store.Application.Abstractions.Commons;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.CategoryRequests;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface ICategoryRepository: ICreateRepository<Category>, IReadRepository<ResponseCategoryDto, GetCategoriesRequest>, IUpdateRepository<Category>, IDeleteRepository<Category>
    {
        Task<bool> ExistsAsync(int id, CancellationToken ct);
    }
}
