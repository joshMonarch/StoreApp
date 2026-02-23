using MediatR;
using Store.Application.DTOs;
using Store.Domain.Commons;
using System.Collections.ObjectModel;

namespace Store.Application.MediatRHandlers.Requests.CategoryRequests
{
    public class GetCategoriesRequest: IRequest<Result<ReadOnlyCollection<ResponseCategoryDto>>>
    {
        public string? CategoryName { get; }
        public DateOnly? FromDate { get; }
        public DateOnly? ToDate { get; }

        public GetCategoriesRequest(string? categoryName, DateOnly? fromDate, DateOnly? toDate)
        {
            CategoryName = categoryName;
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
