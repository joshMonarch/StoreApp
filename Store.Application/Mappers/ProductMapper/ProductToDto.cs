using Store.Application.DTOs;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.Mappers.ProductMapper
{
    public class ProductToDto
    {
        public static ResponseProductDto ToDto(Product product)
        {
            return new ResponseProductDto(
                    product.Id,
                    product.UserId,
                    product.CategoryId,
                    product.Name,
                    product.Stock,
                    product.CreatedAt,
                    product.UpdatedAt
                );
        }
        public static ReadOnlyCollection<ResponseProductDto> ToDtoList(ReadOnlyCollection<Product> products)
        {
            return products.Select(ToDto).ToList().AsReadOnly();
        }
    }
}
