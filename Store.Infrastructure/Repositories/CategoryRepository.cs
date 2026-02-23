using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Commons.Specifications;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;
using System.Collections.ObjectModel;
using System.Linq;

namespace Store.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public Task<ReadOnlyCollection<Category>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<Category>> GetFilteredAsync(ISpecification<Category> spec, CancellationToken ct)
        {
            IQueryable<Category> query = _dbContext.Categories
                .Where(spec.Condition);

            var list = await query.ToListAsync(ct);

            return list.AsReadOnly();
        }

        public Task<int> UpdateAsync(Category entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
