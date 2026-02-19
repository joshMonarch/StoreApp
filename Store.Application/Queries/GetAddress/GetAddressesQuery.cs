using Store.Application.Abstractions.CQRS;
using Store.Application.DTOs;
using System.Collections.ObjectModel;

namespace Store.Application.Queries.GetAddress
{
    public class GetAddressesQuery : IQuery<ReadOnlyCollection<ResponseAddressDto>>
    {
        public int? UserId { get; }
        public string? Country { get; }
        public string? Region { get; }
        public string? City { get; }
        public DateOnly? FromDate { get; }
        public DateOnly? ToDate { get; }

        public GetAddressesQuery(int? userId, string? country, string? region, string? city, DateOnly? fromDate, DateOnly? toDate)
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
