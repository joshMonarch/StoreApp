using MediatR;
using Store.Application.Abstractions;
using Store.Application.Abstractions.Messaging;
using Store.Application.Events.AddressEvents;
using Store.Application.Mappers.AddressMapper;
using Store.Application.MediatRHandlers.Requests.AddressRequests;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.RequestHandlers.AddressHandlers
{
    public class CreateAddressHandler: IRequestHandler<CreateAddressRequest, Result<int>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IEventBus _eventBus;
        private readonly List<IDomainEvent> _events = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _events.AsReadOnly();

        public CreateAddressHandler(IAddressRepository addressRepository, IEventBus eventBus)
        {
            _eventBus = eventBus;
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

            _events.Add(new AddressCreatedEvent(
                result,
                address.Data.UserId.Value,
                address.Data.LocationId.Value,
                address.Data.Country,
                address.Data.Region,
                address.Data.City,
                address.Data.Name,
                address.Data.Number.Value,
                address.Data.Floor.Value,
                address.Data.Door));

            foreach (var evt in DomainEvents)
            {
                await _eventBus.PublishAsync(evt, ct);
            }

            return Result<int>.Ok(result);
        }
    }
}
