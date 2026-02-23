using Microsoft.EntityFrameworkCore;
using Store.Application.Abstractions;
using Store.Application.Commons.Specifications;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;
using System.Collections.ObjectModel;
using System.Linq;

namespace Store.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _dbContext;
        public LocationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> CreateAsync(Location entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Location entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<Location>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ReadOnlyCollection<Location>> GetFilteredAsync(ISpecification<Location> spec, CancellationToken ct)
        {
            IQueryable<Location> query = _dbContext.Locations
                .Where(spec.Condition);

            var list = await query.ToListAsync(ct);

            return list.AsReadOnly();
        }

        public Task<int> UpdateAsync(Location entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
