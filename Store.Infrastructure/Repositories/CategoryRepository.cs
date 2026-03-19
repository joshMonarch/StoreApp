using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.CategoryRequests;
using Store.Domain.Entities;
using Store.Infrastructure.Builders;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.Mongo.FilterBuilders;
using Store.Infrastructure.Persistence.Mongo.ReadModels;
using Store.Infrastructure.Persistence.SQLServer;
using System.Collections.ObjectModel;

namespace Store.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMongoCollection<CategoryReadModel> _collection;

        public CategoryRepository(AppDbContext dbContext, MongoDbContext context)
        {
            _dbContext = dbContext;
            _collection = context.GetCollection<CategoryReadModel>("categories");

        }

        public async Task<int> CreateAsync(Category entity, CancellationToken ct)
        {
            var result = _dbContext.Categories.Add(entity);
            await _dbContext.SaveChangesAsync(ct);
            return result.Entity.Id;
        }

        public Task<int> DeleteAsync(Category entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken ct)
        {
            return await _dbContext.Categories.AnyAsync(c => c.Id == id, ct);
        }

        public Task<ReadOnlyCollection<ResponseCategoryDto>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseCategoryDto> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<ResponseCategoryDto>> GetFilteredAsync(GetCategoriesRequest request, CancellationToken ct)
        {
            var filter = CategoryFilterBuilder.Build(request);

            var list = await _collection
                .Find(filter)
                .ToListAsync(ct);

            return list
                .Select(doc => new ResponseCategoryDto(
                        doc.Id,
                        doc.CategoryName,
                        doc.CreatedAt,
                        doc.UpdatedAt))
                .ToList()
                .AsReadOnly();
        }

        public Task<int> UpdateAsync(Category entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
