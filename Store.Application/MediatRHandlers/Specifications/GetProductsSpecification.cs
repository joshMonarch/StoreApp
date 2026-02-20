using Store.Application.Commons.Specifications;
using Store.Domain.Entities;

namespace Store.Application.MediatRHandlers.Requests.GetProduct
{
    public class GetProductsSpecification: BaseSpecification<Product>
    {
        public GetProductsSpecification(int? userId, int? categoryId, DateTime? fromDate, DateTime? toDate)
        {
            Condition = p =>
                p.UserId == userId &&
                (!categoryId.HasValue || p.CategoryId == categoryId.Value) &&
                (!fromDate.HasValue || p.CreatedAt >= fromDate.Value) &&
                (!toDate.HasValue || p.CreatedAt <= toDate.Value);
        }
    }
}
