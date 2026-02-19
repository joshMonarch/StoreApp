using Store.Application.Abstractions.CQRS;
using Store.Application.DTOs;
using System.Collections.ObjectModel;

namespace Store.Application.Queries.GetUser
{
    public class GetUsersQuery: IQuery<ReadOnlyCollection<ResponseUserDto>>
    {
        public DateOnly? FromBirthDate { get; }
        public DateOnly? ToBirthDate { get; }
        public DateOnly? FromDate { get; }
        public DateOnly? ToDate { get; }

        public GetUsersQuery(DateOnly? fromDate, DateOnly? toDate, DateOnly? fromBirthDate, DateOnly? toBirthDate)
        {
            FromDate = fromDate;
            ToDate = toDate;
            FromBirthDate = fromBirthDate;
            ToBirthDate = toBirthDate;
        }
    }
}
