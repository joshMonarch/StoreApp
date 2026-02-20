using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Commons.Specifications;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;
using System.Collections.ObjectModel;

namespace Store.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> CreateAsync(Product entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Product entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<Product>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<Product>> GetFilteredAsync(ISpecification<Product> spec, CancellationToken ct)
        {
            IQueryable<Product> query = _dbContext.Products
                .Where(spec.Condition);

            var list = await query.ToListAsync(ct);

            return list.AsReadOnly();
        }

        public Task<int> UpdateAsync(Product entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
