using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.ProductRequest;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence.Mongo;
using Store.Infrastructure.Persistence.Mongo.FilterBuilders;
using Store.Infrastructure.Persistence.Mongo.ReadModels;
using Store.Infrastructure.Persistence.SQLServer;
using System.Collections.ObjectModel;

namespace Store.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMongoCollection<ProductReadModel> _collection;
        public ProductRepository(AppDbContext dbContext, MongoDbContext context)
        {
            _dbContext = dbContext;
            _collection = context.GetCollection<ProductReadModel>("products");
        }

        public async Task<int> CreateAsync(Product entity, CancellationToken ct)
        {
            var result = _dbContext.Products.Add(entity);
            await _dbContext.SaveChangesAsync(ct);
            return result.Entity.Id;
        }

        public Task<int> DeleteAsync(Product entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<ResponseProductDto>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseProductDto> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<ResponseProductDto>> GetFilteredAsync(GetProductsRequest request, CancellationToken ct)
        {
            var filter = ProductFilterBuilder.Build(request);

            var list = await _collection
                .Find(filter)
                .ToListAsync(ct);

            return list
                .Select(doc => new ResponseProductDto(
                        doc.Id,
                        doc.UserId,
                        doc.CategoryId,
                        doc.Name,
                        doc.Stock,
                        doc.CreatedAt,
                        doc.UpdatedAt))
                .ToList()
                .AsReadOnly();
        }

        public Task<int> UpdateAsync(Product entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
