using MediatR;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.AddressRequests;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.RequestHandlers.AddressHandlers
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

            ReadOnlyCollection<ResponseAddressDto> addresses = await _addressRepository.GetFilteredAsync(request, ct);

            return Result<ReadOnlyCollection<ResponseAddressDto>>.Ok(addresses);
        }
    }
}
