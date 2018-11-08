using System.Collections.Generic;
using SametKabay.Application.BlogPostServices.Dto;

namespace SametKabay.Application.BlogPostServices
{
    public interface IBlogPostAppService
    {
        void InsertBlogPost(BlogPostInputModel input);

        List<BlogPostGetAllOutputModel> GetAll(PagedAndSortedInputDto input);
        BlogPostOutputModel GetById(int id, int userId);
        BlogPostOutputModel GetByTitle(string title, int userId);
        List<BlogPostPreviewOutputModel> Random(int count);

    }
}