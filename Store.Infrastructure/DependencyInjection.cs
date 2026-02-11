using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Abstractions;
using Store.Infrastructure.Persistence;

namespace Store.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("SqlServerConnection")));

        #region User
        services.AddScoped<IUserRepository, IUserRepository>();
        #endregion
        #region Address
        services.AddScoped<IAddressRepository, IAddressRepository>();
        #endregion
        #region Product
        services.AddScoped<IProductRepository, IProductRepository>();
        #endregion
        #region Location
        services.AddScoped<ILocationRepository, ILocationRepository>();
        #endregion
        #region Category
        services.AddScoped<ICategoryRepository, ICategoryRepository>();
        #endregion

        return services;
    }
}
