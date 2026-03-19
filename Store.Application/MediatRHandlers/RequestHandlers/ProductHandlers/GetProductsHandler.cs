using MediatR;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.ProductRequest;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.RequestHandlers.ProductHandlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, Result<ReadOnlyCollection<ResponseProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductsHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<ReadOnlyCollection<ResponseProductDto>>> Handle(GetProductsRequest request, CancellationToken ct)
        {
            if (request.UserId is null)
                return Result<ReadOnlyCollection<ResponseProductDto>>.Fail("UserId not found.");
            if (request.FromDate > request.ToDate)
                return Result<ReadOnlyCollection<ResponseProductDto>>.Fail("FromDate cannot be greater than ToDate.");
            
            if (request.CategoryId is not null)
            {
                bool categoryExists = await _categoryRepository.ExistsAsync(request.CategoryId.Value, ct);
                if (!categoryExists)
                    return Result<ReadOnlyCollection<ResponseProductDto>>.Fail("Category not found.");
            }

            ReadOnlyCollection<ResponseProductDto> products = await _productRepository.GetFilteredAsync(request, ct);
            
            return Result<ReadOnlyCollection<ResponseProductDto>>.Ok(products);
        }
    }
}
