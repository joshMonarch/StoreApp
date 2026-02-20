using Store.Application.Commons.Specifications;
using Store.Domain.Entities;

namespace Store.Application.MediatRHandlers.Specifications
{
    public class GetUsersSpecification: BaseSpecification<User>
    {
        public GetUsersSpecification(DateOnly? fromBirthDate, DateOnly? toBirthDate, DateOnly? fromDate, DateOnly? toDate)
        {
            Condition = u =>
            (fromBirthDate.HasValue && 
            u.BirthDate > fromBirthDate) &&
            (toBirthDate.HasValue &&
            u.BirthDate < toBirthDate) &&
            (fromDate.HasValue &&
            u.CreatedAt >= fromDate.Value.ToDateTime(TimeOnly.MinValue)) &&
            (toDate.HasValue &&
            u.CreatedAt <= toDate.Value.ToDateTime(TimeOnly.MinValue));
        }
    }
}
