using Store.Application.Commons.Specifications;
using Store.Domain.Entities;

namespace Store.Application.MediatRHandlers.Specifications
{
    public class GetCategoriesSpecification: BaseSpecification<Category>
    {
        public GetCategoriesSpecification(string? categoryName, DateOnly? fromDate, DateOnly? toDate)
        {
            Condition = c =>
                (string.IsNullOrWhiteSpace(categoryName) || c.CategoryName == categoryName) &&
                (!fromDate.HasValue || c.CreatedAt >= fromDate.Value.ToDateTime(TimeOnly.MinValue)) &&
                (!toDate.HasValue || c.CreatedAt <= toDate.Value.ToDateTime(TimeOnly.MaxValue));
        }
    }
}
