using MediatR;
using Store.Application.DTOs;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.Requests.LocationRequests
{
    public class GetLocationsRequest: IRequest<Result<ReadOnlyCollection<ResponseLocationDto>>>
    {
        public string? LocationType { get; }
        public DateOnly? FromDate { get; }
        public DateOnly? ToDate { get; }

        public GetLocationsRequest(string? locationType, DateOnly? fromDate, DateOnly? toDate)
        {
            LocationType = locationType;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
