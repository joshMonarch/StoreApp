using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Domain.Entities;

namespace Store.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;
        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> CreateAsync(User entity, CancellationToken ct)
        {
            throw new NotImplementedException();

        }

        public Task<int> DeleteAsync(User entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(User entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
