using MongoDB.Driver;
using Store.Application.MediatRHandlers.Requests.UserRequests;
using Store.Infrastructure.Persistence.Mongo.ReadModels;

namespace Store.Infrastructure.Persistence.Mongo.FilterBuilders
{
    public class UserFilterBuilder
    {
        public static FilterDefinition<UserReadModel> Build(GetUsersRequest request)
        {
            var builder = Builders<UserReadModel>.Filter;
            var filter = builder.Empty;

            if (request.FromBirthDate.HasValue)
                filter &= builder.Gte(u => u.BirthDate, request.FromBirthDate.Value);
            
            if (request.ToBirthDate.HasValue)
                filter &= builder.Lte(u => u.BirthDate, request.ToBirthDate.Value);

            if (request.FromDate.HasValue)
                filter &= builder.Gte(u => u.CreatedAt, request.FromDate.Value.ToDateTime(TimeOnly.MinValue));

            if (request.ToDate.HasValue)
                filter &= builder.Lte(u => u.CreatedAt, request.ToDate.Value.ToDateTime(TimeOnly.MaxValue));

            return filter;
        }
    }
}
