using Store.Application.Abstractions.Commons;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.AddressRequests;
using Store.Domain.Entities;

namespace Store.Application.Abstractions
{
    public interface IAddressRepository: ICreateRepository<Address>, IReadRepository<ResponseAddressDto, GetAddressesRequest>, IUpdateRepository<Address>, IDeleteRepository<Address>
    {
    }
}
