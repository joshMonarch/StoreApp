using Store.Application.Commons.Specifications;
using Store.Domain.Entities;

namespace Store.Application.MediatRHandlers.Specifications
{
    public class GetLocationsSpecification : BaseSpecification<Location>
    {
        public GetLocationsSpecification(string? locationType, DateOnly? fromDate, DateOnly? toDate) 
        {
            Condition = l =>
                (string.IsNullOrWhiteSpace(locationType) || l.LocationType == locationType) && 
                (!fromDate.HasValue || l.CreatedAt >= fromDate.Value.ToDateTime(TimeOnly.MinValue)) &&
                (!toDate.HasValue || l.CreatedAt <= toDate.Value.ToDateTime(TimeOnly.MaxValue));
        }
    }
}
