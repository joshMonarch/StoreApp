using MediatR;
using Store.Application.DTOs;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.Requests
{
    public class GetAddressesRequest : IRequest<Result<ReadOnlyCollection<ResponseAddressDto>>>
    {
        public int? UserId { get; }
        public string? Country { get; }
        public string? Region { get; }
        public string? City { get; }
        public DateOnly? FromDate { get; }
        public DateOnly? ToDate { get; }

        public GetAddressesRequest(int? userId, string? country, string? region, string? city, DateOnly? fromDate, DateOnly? toDate)
        {
            UserId = userId;
            Country = country;
            Region = region;
            City = city;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
