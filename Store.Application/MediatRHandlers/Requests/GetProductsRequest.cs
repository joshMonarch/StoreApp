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
        public DateTime? FromDate { get; }
        public DateTime? ToDate { get; }

        public GetProductsRequest(int? userId, int? categoryId, DateTime? fromDate, DateTime? toDate)
        {
            UserId = userId;
            CategoryId = categoryId;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
