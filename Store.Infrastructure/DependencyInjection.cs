using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Abstractions;
using Store.Infrastructure.Persistence;
using Store.Infrastructure.Repositories;

namespace Store.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("SqlServerConnection")));

        #region User
        services.AddScoped<IUserRepository, UserRepository>();
        #endregion
        #region Address
        services.AddScoped<IAddressRepository, AddressRepository>();
        #endregion
        #region Product
        services.AddScoped<IProductRepository, ProductRepository>();
        #endregion
        #region Location
        services.AddScoped<ILocationRepository, LocationRepository>();
        #endregion
        #region Category
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        #endregion

        return services;
    }
}
