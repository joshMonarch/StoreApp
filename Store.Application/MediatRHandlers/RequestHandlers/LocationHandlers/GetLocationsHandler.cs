using MediatR;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.MediatRHandlers.Requests.LocationRequests;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.RequestHandlers.LocationHandlers
{
    public class GetLocationsHandler : IRequestHandler<GetLocationsRequest, Result<ReadOnlyCollection<ResponseLocationDto>>>
    {
        private readonly ILocationRepository _locationRepository;
        public GetLocationsHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Result<ReadOnlyCollection<ResponseLocationDto>>> Handle(GetLocationsRequest request, CancellationToken ct)
        {
            ReadOnlyCollection<ResponseLocationDto> locations = await _locationRepository.GetFilteredAsync(request, ct);

            return Result<ReadOnlyCollection<ResponseLocationDto>>.Ok(locations);
        }
    }
}
