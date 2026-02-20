using MediatR;
using Store.Application.Abstractions;
using Store.Application.Mappers.AddressMapper;
using Store.Application.MediatRHandlers.Requests.AddressRequests;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.RequestHandlers.AddressHandlers
{
    public class CreateAddressHandler: IRequestHandler<CreateAddressRequest, Result<int>>
    {
        private readonly IAddressRepository _addressRepository;

        public CreateAddressHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Result<int>> Handle(CreateAddressRequest request, CancellationToken ct)
        {
            var address = AddressToEntity.ToEntity(request);

            if (!address.IsSuccess)
                return Result<int>.Fail($"Invalid address data: {address.Error}");

            var result = await _addressRepository.CreateAsync(address.Data, ct);

            if (result <= 0)
                return Result<int>.Fail("Failed to create address.");

            return Result<int>.Ok(result);
        }
    }
}
