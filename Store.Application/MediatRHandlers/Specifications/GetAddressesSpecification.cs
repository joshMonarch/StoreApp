using Store.Application.Commons.Specifications;
using Store.Domain.Entities;

namespace Store.Application.MediatRHandlers.Requests.GetAddress
{
    public class GetAddressesSpecification: BaseSpecification<Address>
    {
        public GetAddressesSpecification(int? userId, string? country, string? region, string? city, DateOnly? fromDate, DateOnly? toDate)
        {
            Condition = a => 
            (userId.HasValue || a.UserId == userId) && 
            (string.IsNullOrWhiteSpace(country) || a.Country == country) && 
            (string.IsNullOrWhiteSpace(region) || a.Region == region) && 
            (string.IsNullOrWhiteSpace(city) || a.City == city) &&
            (fromDate.HasValue && 
                a.CreatedAt > fromDate.Value.ToDateTime(TimeOnly.MinValue)) &&
            (toDate.HasValue && 
                a.CreatedAt < toDate.Value.ToDateTime(TimeOnly.MinValue));
        }
    }
}
