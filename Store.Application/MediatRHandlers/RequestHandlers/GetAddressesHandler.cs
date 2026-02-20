using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.Mappers.AddressMapper;
using Store.Application.MediatRHandlers.Requests;
using Store.Domain.Commons;
using Store.Domain.Entities;
using System.Collections.ObjectModel;
using MediatR;
using Store.Application.MediatRHandlers.Specifications;

namespace Store.Application.MediatRHandlers.RequestHandlers
{
    public class GetAddressesHandler : IRequestHandler<GetAddressesRequest, Result<ReadOnlyCollection<ResponseAddressDto>>>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAddressesHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Result<ReadOnlyCollection<ResponseAddressDto>>> Handle(GetAddressesRequest request, CancellationToken ct)
        {

            if (!request.UserId.HasValue)
                return Result<ReadOnlyCollection<ResponseAddressDto>>.Fail("UserId not found.");
            if (request.FromDate > request.ToDate)
                return Result<ReadOnlyCollection<ResponseAddressDto>>.Fail("FromDate cannot be greater than ToDate.");

            var spec = new GetAddressesSpecification(request.UserId, request.Country, request.Region, request.City, request.FromDate, request.ToDate);

            ReadOnlyCollection<Address> addresses = await _addressRepository.GetFilteredAsync(spec, ct);

            return Result<ReadOnlyCollection<ResponseAddressDto>>.Ok(AddressToDto.ToDtoList(addresses));
        }
    }
}
