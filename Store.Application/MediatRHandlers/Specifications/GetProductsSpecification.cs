using Store.Application.Commons.Specifications;
using Store.Domain.Entities;

namespace Store.Application.MediatRHandlers.Requests.GetProduct
{
    public class GetProductsSpecification: BaseSpecification<Product>
    {
        public GetProductsSpecification(int? userId, int? categoryId, DateOnly? fromDate, DateOnly? toDate)
        {
            Condition = p =>
                (!userId.HasValue || p.UserId == userId) &&
                (!categoryId.HasValue || p.CategoryId == categoryId.Value) &&
                (!fromDate.HasValue || p.CreatedAt >= fromDate.Value.ToDateTime(TimeOnly.MinValue)) &&
                (!toDate.HasValue || p.CreatedAt <= toDate.Value.ToDateTime(TimeOnly.MaxValue));
        }
    }
}
