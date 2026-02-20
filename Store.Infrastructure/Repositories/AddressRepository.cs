using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Commons.Specifications;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;
using System.Collections.ObjectModel;

namespace Store.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _dbContext;
        public AddressRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateAsync(Address entity, CancellationToken ct)
        {
            var result = _dbContext.Addresses.Add(entity);
            await _dbContext.SaveChangesAsync(ct);
            return result.Entity.Id;
        }

        public Task<int> DeleteAsync(Address entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<Address>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<Address>> GetFilteredAsync(ISpecification<Address> spec, CancellationToken ct)
        {
            IQueryable<Address> query = _dbContext.Addresses
                .Where(spec.Condition);

            var list = await query.ToListAsync(ct);

            return list.AsReadOnly();
        }

        public Task<int> UpdateAsync(Address entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
