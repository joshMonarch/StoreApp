using Store.Application.Abstractions.Commons;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.ProductRequest;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface IProductRepository: ICreateRepository<Product>, IReadRepository<ResponseProductDto, GetProductsRequest>, IUpdateRepository<Product>, IDeleteRepository<Product>
    {
    }
}
