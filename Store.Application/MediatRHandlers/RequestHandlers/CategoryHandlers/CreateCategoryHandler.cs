using MediatR;
using Store.Application.Abstractions;
using Store.Application.Mappers.CategoryMapper;
using Store.Application.MediatRHandlers.Requests.CategoryRequests;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.RequestHandlers.CategoryHandlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, Result<int>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<int>> Handle(CreateCategoryRequest request, CancellationToken ct)
        {
            var category = CategoryToEntity.ToEntity(request);

            if (!category.IsSuccess)
                return Result<int>.Fail($"Invalid address data: {category.Error}");

            var result = await _categoryRepository.CreateAsync(category.Data, ct);

            if (result <= 0)
                return Result<int>.Fail("Failed to create address.");

            return Result<int>.Ok(result);
        }
    }
}
