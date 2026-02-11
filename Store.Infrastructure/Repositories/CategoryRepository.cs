using Store.Application.Abstractions;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;

namespace Store.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> CreateAsync(Category entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Category entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Category entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
