using Store.Application.MediatRHandlers.Requests.CategoryRequests;
using Store.Domain.Commons;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.Mappers.CategoryMapper
{
    public class CategoryToEntity
    {
        public static Result<Category> ToEntity(CreateCategoryRequest request)
        {
            return Category.Create(request.CategoryName);
        }
    }
}
