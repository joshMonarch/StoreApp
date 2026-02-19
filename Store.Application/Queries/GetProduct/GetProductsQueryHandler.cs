using Store.Application.Abstractions;
using Store.Application.Abstractions.CQRS;
using Store.Application.DTOs;
using Store.Application.Mappers.ProductMapper;
using Store.Domain.Commons;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.Queries.GetProduct
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, ReadOnlyCollection<ResponseProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetProductsQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<ReadOnlyCollection<ResponseProductDto>>> Handle(GetProductsQuery query, CancellationToken ct)
        {
            if (query.UserId is null)
                return Result<ReadOnlyCollection<ResponseProductDto>>.Fail("UserId not found.");
            if (query.FromDate > query.ToDate)
                return Result<ReadOnlyCollection<ResponseProductDto>>.Fail("FromDate cannot be greater than ToDate.");
            
            bool categoryExists = await _productRepository.CategoryExistsAsync(query.CategoryId, ct);

            var spec = new GetProductsSpecification(query.UserId, query.CategoryId, query.FromDate, query.ToDate);

            ReadOnlyCollection<Product> products = await _productRepository.GetFilteredAsync(spec, ct);
            
            return Result<ReadOnlyCollection<ResponseProductDto>>.Ok(ProductToDto.ToDtoList(products));
        }
    }
}
