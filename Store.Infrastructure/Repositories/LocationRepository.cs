using Store.Application.Abstractions;
using Store.Domain.Entities;
using Store.Infrastructure.Persistence;

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

        public Task<Location> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Location> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Location entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
