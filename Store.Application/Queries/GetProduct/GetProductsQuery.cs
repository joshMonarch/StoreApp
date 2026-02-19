using Store.Application.Abstractions.CQRS;
using Store.Application.DTOs;
using System.Collections.ObjectModel;

namespace Store.Application.Queries.GetProduct
{
    public class GetProductsQuery: IQuery<ReadOnlyCollection<ResponseProductDto>>
    {
        public int? UserId { get; }
        public int? CategoryId { get; }
        public DateTime? FromDate { get; }
        public DateTime? ToDate { get; }

        public GetProductsQuery(int? userId, int? categoryId, DateTime? fromDate, DateTime? toDate)
        {
            UserId = userId;
            CategoryId = categoryId;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
