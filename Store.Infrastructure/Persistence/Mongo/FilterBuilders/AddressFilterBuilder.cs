using MongoDB.Driver;
using Store.Application.MediatRHandlers.Requests.AddressRequests;
using Store.Infrastructure.Persistence.ReadModels;

namespace Store.Infrastructure.Builders;

public static class AddressFilterBuilder
{
    public static FilterDefinition<AddressReadModel> Build(GetAddressesRequest request)
    {
        var builder = Builders<AddressReadModel>.Filter;
        var filter = builder.Empty;

        if (request.UserId.HasValue)
            filter &= builder.Eq(a => a.UserId, request.UserId.Value);

        if (!string.IsNullOrWhiteSpace(request.Country))
            filter &= builder.Eq(a => a.Country, request.Country);

        if (!string.IsNullOrWhiteSpace(request.Region))
            filter &= builder.Eq(a => a.Region, request.Region);

        if (!string.IsNullOrWhiteSpace(request.City))
            filter &= builder.Eq(a => a.City, request.City);

        if (request.FromDate.HasValue)
            filter &= builder.Gte(a => a.CreatedAt, request.FromDate.Value.ToDateTime(TimeOnly.MinValue));

        if (request.ToDate.HasValue)
            filter &= builder.Lte(a => a.CreatedAt, request.ToDate.Value.ToDateTime(TimeOnly.MaxValue));

        return filter;
    }
}