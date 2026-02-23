using MediatR;
using Store.Application.Abstractions;
using Store.Application.Mappers.LocationMapper;
using Store.Application.MediatRHandlers.Requests.LocationRequests;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.RequestHandlers.LocationHandlers
{
    public class CreateLocationHandler : IRequestHandler<CreateLocationRequest, Result<int>>
    {
        private readonly ILocationRepository _locationRepository;

        public CreateLocationHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Result<int>> Handle(CreateLocationRequest request, CancellationToken ct)
        {
            var location = LocationToEntity.ToEntity(request);

            if (!location.IsSuccess)
                return Result<int>.Fail($"Invalid address data: {location.Error}");

            var result = await _locationRepository.CreateAsync(location.Data, ct);

            if (result <= 0)
                return Result<int>.Fail("Failed to create address.");

            return Result<int>.Ok(result);
        }
    }
}
