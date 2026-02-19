using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Commons.Specifications;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;
using System.Collections.ObjectModel;

namespace Store.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public Task<int> CreateAsync(Category entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Category entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken ct)
        {
            return await _dbContext.Categories.AnyAsync(c => c.Id == id, ct);
        }

        public Task<ReadOnlyCollection<Category>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<Category>> GetFilteredAsync(ISpecification<Category> spec, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Category entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
