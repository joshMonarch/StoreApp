using MediatR;
using Store.Domain.Commons;

namespace Store.Application.MediatRHandlers.Requests.CategoryRequests
{
    public class CreateCategoryRequest: IRequest<Result<int>>
    {
        public string? CategoryName { get; }

        public CreateCategoryRequest(string? categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
