using Store.Application.Abstractions;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;

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

        public Task<Product> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Product entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
