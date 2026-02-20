using Store.Application.MediatRHandlers.Requests.ProductRequest;
using Store.Domain.Commons;
using Store.Domain.Entities;

namespace Store.Application.Mappers.ProductMapper
{
    public class ProductToEntity
    {
        public static Result<Product> ToEntity(CreateProductRequest request)
        {
            return Product.Create(
                request.UserId,
                request.CategoryId,
                request.Name,
                request.Stock
            );

        }
    }
}
