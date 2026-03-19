using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.UserRequests;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.Mongo.FilterBuilders;
using Store.Infrastructure.Persistence.Mongo.ReadModels;
using Store.Infrastructure.Persistence.SQLServer;
using System.Collections.ObjectModel;

namespace Store.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMongoCollection<UserReadModel> _collection;
        public UserRepository(AppDbContext dbContext, MongoDbContext context)
        {
            _dbContext = dbContext;
            _collection = context.GetCollection<UserReadModel>("users");
        }
        public async Task<int> CreateAsync(User entity, CancellationToken ct)
        {
            var result = _dbContext.Users.Add(entity);
            await _dbContext.SaveChangesAsync(ct);
            return result.Entity.Id;
        }

        public Task<int> DeleteAsync(User entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<ResponseUserDto>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseUserDto> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<ResponseUserDto>> GetFilteredAsync(GetUsersRequest request, CancellationToken ct)
        {
            var filter = UserFilterBuilder.Build(request);

            var list = await _collection
                .Find(filter)
                .ToListAsync(ct);

            return list
                .Select(doc => new ResponseUserDto(
                        doc.Id,
                        doc.Username,
                        doc.Email,
                        doc.Password,
                        doc.BirthDate,
                        doc.CreatedAt,
                        doc.UpdatedAt))
                .ToList()
                .AsReadOnly();
        }

        public Task<int> UpdateAsync(User entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
