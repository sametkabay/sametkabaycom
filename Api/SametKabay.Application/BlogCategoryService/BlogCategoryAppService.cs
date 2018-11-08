using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SametKabay.Application.BlogCategoryService.Dto;
using SametKabay.Application.Extensions;
using SametKabay.Core.Extensions;
using SametKabay.Core.Repositories.BlogCategory;

namespace SametKabay.Application.BlogCategoryService
{
    public class BlogCategoryAppService : IBlogCategoryAppService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        public BlogCategoryAppService(IBlogCategoryRepository blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public List<GetCategoriesOutputModel> GetCategories()
        {
            var model = _blogCategoryRepository.GetAll()
                .WhereIsActive(true)
                .WhereIsDeleted(false)
                .Select(p => new GetCategoriesOutputModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    SafeName = p.SafeName
                }).ToList();
            return model;
        }

        public List<GetCategoriesDetailOutputModel> GetCategoriesDetail(int? id, string name)
        {
            var model = _blogCategoryRepository.GetAll()
                .Include(p => p.PostCategory)
                .WhereIsActive(true)
                .WhereIsDeleted(false)
                .WhereIf(id != null, p => p.Id == id)
                .WhereIf(name != null, p => p.SafeName == name)
                .Select(p => new GetCategoriesDetailOutputModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    SafeName = p.SafeName,
                    Detail = p.Detail,
                    ImageUrl = p.PictureUrl,
                    PostCount = p.PostCategory.Count()
                }).ToList();
            return model;
        }
    }
}
