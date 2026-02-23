using MediatR;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.Mappers.CategoryMapper;
using Store.Application.MediatRHandlers.Requests.CategoryRequests;
using Store.Application.MediatRHandlers.Specifications;
using Store.Domain.Commons;
using Store.Domain.Entities;
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
            var spec = new GetCategoriesSpecification(request.CategoryName, request.FromDate, request.ToDate);

            ReadOnlyCollection<Category> categories = await _categoryRepository.GetFilteredAsync(spec, ct);

            return Result<ReadOnlyCollection<ResponseCategoryDto>>.Ok(CategoryToDto.ToDtoList(categories));
        }
    }
}
