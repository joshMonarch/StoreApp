using MediatR;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.CategoryRequests;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.RequestHandlers.CategoryHandlers
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesRequest, Result<ReadOnlyCollection<ResponseCategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoriesHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<ReadOnlyCollection<ResponseCategoryDto>>> Handle(GetCategoriesRequest request, CancellationToken ct)
        {
            if (request.FromDate > request.ToDate)
                return Result<ReadOnlyCollection<ResponseCategoryDto>>.Fail("FromDate cannot be greater than ToDate.");

            ReadOnlyCollection<ResponseCategoryDto> categories = await _categoryRepository.GetFilteredAsync(request, ct);

            return Result<ReadOnlyCollection<ResponseCategoryDto>>.Ok(categories);
        }
    }
}
