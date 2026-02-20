using MediatR;
using Store.Application.DTOs;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.Requests
{
    public class GetProductsRequest: IRequest<Result<ReadOnlyCollection<ResponseProductDto>>>
    {
        public int? UserId { get; }
        public int? CategoryId { get; }
        public DateOnly? FromDate { get; }
        public DateOnly? ToDate { get; }

        public GetProductsRequest(int? userId, int? categoryId, DateOnly? fromDate, DateOnly? toDate)
        {
            UserId = userId;
            CategoryId = categoryId;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
