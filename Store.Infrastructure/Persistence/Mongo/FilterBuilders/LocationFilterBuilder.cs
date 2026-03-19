using MongoDB.Driver;
using Store.Application.MediatRHandlers.Requests.LocationRequests;
using Store.Infrastructure.Persistence.Mongo.ReadModels;

namespace Store.Infrastructure.Persistence.Mongo.FilterBuilders
{
    public class LocationFilterBuilder
    {
        public static FilterDefinition<LocationReadModel> Build(GetLocationsRequest request)
        {
            var builder = Builders<LocationReadModel>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrWhiteSpace(request.LocationType))
                filter &= builder.Eq(l => l.LocationType, request.LocationType);

            if (request.FromDate.HasValue)
                filter &= builder.Gte(l => l.CreatedAt, request.FromDate.Value.ToDateTime(TimeOnly.MinValue));

            if (request.ToDate.HasValue)
                filter &= builder.Lte(l => l.CreatedAt, request.ToDate.Value.ToDateTime(TimeOnly.MaxValue));

            return filter;
        }
    }
}
