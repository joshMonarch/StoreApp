using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.LocationRequests;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.Mongo.FilterBuilders;
using Store.Infrastructure.Persistence.Mongo.ReadModels;
using Store.Infrastructure.Persistence.SQLServer;
using System.Collections.ObjectModel;
using System.Linq;

namespace Store.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMongoCollection<LocationReadModel> _collection;
        public LocationRepository(AppDbContext dbContext, MongoDbContext context)
        {
            _dbContext = dbContext;
            _collection = context.GetCollection<LocationReadModel>("locations");
        }

        public Task<int> CreateAsync(Location entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Location entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<ResponseLocationDto>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseLocationDto> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<ResponseLocationDto>> GetFilteredAsync(GetLocationsRequest request, CancellationToken ct)
        {
            var filter = LocationFilterBuilder.Build(request);

            var list = await _collection
                .Find(filter)
                .ToListAsync(ct);

            return list
                .Select(doc => new ResponseLocationDto(
                        doc.Id,
                        doc.LocationType,
                        doc.CreatedAt,
                        doc.UpdatedAt))
                .ToList()
                .AsReadOnly();
        }

        public Task<int> UpdateAsync(Location entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
