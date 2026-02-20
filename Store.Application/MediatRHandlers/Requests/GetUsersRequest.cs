using MediatR;
using Store.Application.DTOs;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.Requests
{
    public class GetUsersRequest: IRequest<Result<ReadOnlyCollection<ResponseUserDto>>>
    {
        public DateOnly? FromBirthDate { get; }
        public DateOnly? ToBirthDate { get; }
        public DateOnly? FromDate { get; }
        public DateOnly? ToDate { get; }

        public GetUsersRequest(DateOnly? fromDate, DateOnly? toDate, DateOnly? fromBirthDate, DateOnly? toBirthDate)
        {
            FromDate = fromDate;
            ToDate = toDate;
            FromBirthDate = fromBirthDate;
            ToBirthDate = toBirthDate;
        }
    }
}
