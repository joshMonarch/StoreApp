using MediatR;
using Store.Application.Abstractions;
using Store.Application.Abstractions.Messaging;
using Store.Application.Events.CategoryEvents;
using Store.Application.Events.LocationEvents;
using Store.Application.Mappers.LocationMapper;
using Store.Application.MediatRHandlers.Requests.LocationRequests;
using Store.Domain.Commons;
using Store.Domain.Entities;

namespace Store.Application.MediatRHandlers.RequestHandlers.LocationHandlers
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationRequest, Result<int>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IEventBus _eventBus;
        private readonly List<IDomainEvent> _events = new();

        public IReadOnlyList<IDomainEvent> DomainEvents => _events.AsReadOnly();

        public CreateLocationHandler(ILocationRepository locationRepository, IEventBus eventBus)
        {
            _locationRepository = locationRepository;
            _eventBus = eventBus;
        }

        public async Task<Result<int>> Handle(CreateLocationRequest request, CancellationToken ct)
        {
            var location = LocationToEntity.ToEntity(request);

            if (!location.IsSuccess)
                return Result<int>.Fail($"Invalid address data: {location.Error}");

            var result = await _locationRepository.CreateAsync(location.Data, ct);

            if (result <= 0)
                return Result<int>.Fail("Failed to create address.");

            _events.Add(new LocationCreatedEvent(
                result,
                location.Data.LocationType));

            foreach (var evt in DomainEvents)
            {
                await _eventBus.PublishAsync(evt, ct);
            }

            return Result<int>.Ok(result);
        }
    }
}
