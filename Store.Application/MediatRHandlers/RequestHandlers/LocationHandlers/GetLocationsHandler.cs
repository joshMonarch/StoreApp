using MediatR;
using Store.Application.Abstractions;
using Store.Application.DTOs;
using Store.Application.Mappers.LocationMapper;
using Store.Application.MediatRHandlers.Requests.LocationRequests;
using Store.Application.MediatRHandlers.Specifications;
using Store.Domain.Commons;
using Store.Domain.Entities;
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
            var spec = new GetLocationsSpecification(request.LocationType, request.FromDate, request.ToDate);

            ReadOnlyCollection<Location> locations = await _locationRepository.GetFilteredAsync(spec, ct);

            return Result<ReadOnlyCollection<ResponseLocationDto>>.Ok(LocationToDto.ToDtoList(locations));
        }
    }
}
