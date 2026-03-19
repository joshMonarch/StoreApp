using MongoDB.Driver;
using Store.Application.MediatRHandlers.Requests.CategoryRequests;
using Store.Infrastructure.Persistence.Mongo.ReadModels;

namespace Store.Infrastructure.Persistence.Mongo.FilterBuilders
{
    public class CategoryFilterBuilder
    {
        public static FilterDefinition<CategoryReadModel> Build(GetCategoriesRequest request)
        {
            var builder = Builders<CategoryReadModel>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrWhiteSpace(request.CategoryName))
                filter &= builder.Eq(c => c.CategoryName, request.CategoryName);

            if (request.FromDate.HasValue)
                filter &= builder.Gte(c => c.CreatedAt, request.FromDate.Value.ToDateTime(TimeOnly.MinValue));

            if (request.ToDate.HasValue)
                filter &= builder.Lte(c => c.CreatedAt, request.ToDate.Value.ToDateTime(TimeOnly.MaxValue));

            return filter;
        }
    }
}
