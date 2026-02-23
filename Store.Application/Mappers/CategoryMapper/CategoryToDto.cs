using Store.Application.DTOs;
using Store.Domain.Entities;
using System.Collections.ObjectModel;

namespace Store.Application.Mappers.CategoryMapper
{
    public class CategoryToDto
    {
        public static ResponseCategoryDto ToDto(Category category)
        {
            return new ResponseCategoryDto(
                category.Id,
                category.CategoryName,
                category.CreatedAt,
                category.UpdatedAt
            );
        }

        public static ReadOnlyCollection<ResponseCategoryDto> ToDtoList(ReadOnlyCollection<Category> categories)
        {
            return categories.Select(ToDto).ToList().AsReadOnly();
        }
    }
}
