using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Commons.Specifications;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;
using System.Collections.ObjectModel;

namespace Store.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public Task<ReadOnlyCollection<User>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<User>> GetFilteredAsync(ISpecification<User> spec, CancellationToken ct)
        {
            IQueryable<User> query = _dbContext.Users
                .Where(spec.Condition);

            var list = await query.ToListAsync(ct);

            return list.AsReadOnly();
        }

        public Task<int> UpdateAsync(User entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
