using Microsoft.Extensions.DependencyInjection;
using Store.Application.Abstractions.CQRS;
using Store.Application.DTOs;
using Store.Application.Queries.GetAddress;
using Store.Application.Queries.GetProduct;
using Store.Application.Queries.GetUser;
using System.Collections.ObjectModel;

namespace Store.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        #region Queries
        services.AddScoped<IQueryHandler<GetUsersQuery, ReadOnlyCollection<ResponseUserDto>>, GetUsersQueryHandler>();
        services.AddScoped<IQueryHandler<GetAddressesQuery, ReadOnlyCollection<ResponseAddressDto>>, GetAddressesQueryHandler>();
        services.AddScoped<IQueryHandler<GetProductsQuery, ReadOnlyCollection<ResponseProductDto>>, GetProductsQueryHandler>();
        #endregion

        return services;
    }
}
