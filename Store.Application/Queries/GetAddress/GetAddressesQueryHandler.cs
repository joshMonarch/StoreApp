using Store.Application.Abstractions;
using Store.Application.Abstractions.CQRS;
using Store.Application.DTOs;
using Store.Application.Mappers.AddressMapper;
using Store.Domain.Commons;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.Queries.GetAddress
{
    public class GetAddressesQueryHandler : IQueryHandler<GetAddressesQuery, ReadOnlyCollection<ResponseAddressDto>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAddressesQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Result<ReadOnlyCollection<ResponseAddressDto>>> Handle(GetAddressesQuery query, CancellationToken ct)
        {

            if (!query.UserId.HasValue)
                return Result<ReadOnlyCollection<ResponseAddressDto>>.Fail("UserId not found.");
            if (query.FromDate > query.ToDate)
                return Result<ReadOnlyCollection<ResponseAddressDto>>.Fail("FromDate cannot be greater than ToDate.");

            var spec = new GetAddressesSpecification(query.UserId, query.Country, query.Region, query.City, query.FromDate, query.ToDate);

            ReadOnlyCollection<Address> addresses = await _addressRepository.GetFilteredAsync(spec, ct);

            return Result<ReadOnlyCollection<ResponseAddressDto>>.Ok(AddressToDto.ToDtoList(addresses));
        }
    }
}
