using MediatR;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.Requests.ProductRequest
{
    public class CreateProductRequest : IRequest<Result<int>>
    {
        public int? UserId { get; }
        public int? CategoryId { get; }
        public string? Name { get; }
        public int? Stock { get; }

        public CreateProductRequest(int? userId, int? categoryId, string? name, int? stock)
        {
            UserId = userId;
            CategoryId = categoryId;
            Name = name;
            Stock = stock;
        }
    }
}
