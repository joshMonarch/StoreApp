using MediatR;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.Mappers.ProductMapper;
using Store.Application.MediatRHandlers.Requests;
using Store.Application.MediatRHandlers.Specifications;
using Store.Domain.Commons;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.RequestHandlers
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

            var spec = new GetProductsSpecification(request.UserId, request.CategoryId, request.FromDate, request.ToDate);

            ReadOnlyCollection<Product> products = await _productRepository.GetFilteredAsync(spec, ct);
            
            return Result<ReadOnlyCollection<ResponseProductDto>>.Ok(ProductToDto.ToDtoList(products));
        }
    }
}
