
using MongoDB.Driver;
using Store.Application.MediatRHandlers.Requests.ProductRequest;
using Store.Infrastructure.Persistence.Mongo.ReadModels;

namespace Store.Infrastructure.Persistence.Mongo.FilterBuilders
{
    public class ProductFilterBuilder
    {
        public static FilterDefinition<ProductReadModel> Build(GetProductsRequest request)
        {
            var builder = Builders<ProductReadModel>.Filter;
            var filter = builder.Empty;

            if (request.UserId.HasValue)
                filter &= builder.Eq(p => p.UserId, request.UserId);

            if (request.CategoryId.HasValue)
                filter &= builder.Eq(p => p.CategoryId, request.CategoryId);

            if (request.FromDate.HasValue)
                filter &= builder.Gte(p => p.CreatedAt, request.FromDate.Value.ToDateTime(TimeOnly.MinValue));

            if (request.ToDate.HasValue)
                filter &= builder.Lte(p => p.CreatedAt, request.ToDate.Value.ToDateTime(TimeOnly.MaxValue));

            return filter;
        }
    }
}
