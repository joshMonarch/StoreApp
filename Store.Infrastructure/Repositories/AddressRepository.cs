using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.AddressRequests;
using Store.Domain.Entities;
using Store.Infrastructure.Builders;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.ReadModels;
using Store.Infrastructure.Persistence.SQLServer;
using System.Collections.ObjectModel;

namespace Store.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMongoCollection<AddressReadModel> _collection;
        public AddressRepository(AppDbContext dbContext, MongoDbContext context)
        {
            _dbContext = dbContext;
            _collection = context.GetCollection<AddressReadModel>("addresses");
        }
        public async Task<int> CreateAsync(Address entity, CancellationToken ct)
        {
            var result = _dbContext.Addresses.Add(entity);
            await _dbContext.SaveChangesAsync(ct);
            return result.Entity.Id;
        }

        public Task<int> DeleteAsync(Address entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<ResponseAddressDto>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseAddressDto> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<ResponseAddressDto>> GetFilteredAsync(GetAddressesRequest request, CancellationToken ct)
        {
            var filter = AddressFilterBuilder.Build(request);

            var list = await _collection
                .Find(filter)
                .ToListAsync(ct);

            return list
                .Select(doc => new ResponseAddressDto(
                        doc.Id,
                        doc.UserId,
                        doc.LocationId,
                        doc.Country,
                        doc.Region,
                        doc.City,
                        doc.Name,
                        doc.Number,
                        doc.Floor,
                        doc.Door,
                        doc.CreatedAt,
                        doc.UpdatedAt))
                .ToList()
                .AsReadOnly();
        }

        public Task<int> UpdateAsync(Address entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
