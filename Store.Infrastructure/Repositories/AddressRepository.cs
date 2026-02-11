using Store.Application.Abstractions;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;

namespace Store.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _dbContext;
        public AddressRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> CreateAsync(Address entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Address entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Address entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
