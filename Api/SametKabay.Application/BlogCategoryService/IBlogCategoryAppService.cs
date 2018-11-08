using System.Collections.Generic;
using SametKabay.Application.BlogCategoryService.Dto;

namespace SametKabay.Application.BlogCategoryService
{
    public interface IBlogCategoryAppService
    {
        List<GetCategoriesOutputModel> GetCategories();
        List<GetCategoriesDetailOutputModel> GetCategoriesDetail(int? id, string name);
    }
}