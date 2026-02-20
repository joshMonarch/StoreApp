using MediatR;
using Store.Application.Abstractions;
using Store.Application.Mappers.ProductMapper;
using Store.Application.MediatRHandlers.Requests.ProductRequest;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.RequestHandlers.ProductHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, Result<int>>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result<int>> Handle(CreateProductRequest request, CancellationToken ct)
        {
            var product = ProductToEntity.ToEntity(request);

            if (!product.IsSuccess)
                return Result<int>.Fail($"Invalid product data: {product.Error}");

            var result = await _productRepository.CreateAsync(product.Data, ct);

            if (result <= 0)
                return Result<int>.Fail("Failed to create product.");

            return Result<int>.Ok(result);
        }
    }
}
