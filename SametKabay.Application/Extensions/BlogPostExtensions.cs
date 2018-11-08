using System.Linq;
using SametKabay.Application.BlogPostServices.Dto;

namespace SametKabay.Application.Extensions
{
    public static class BlogPostExtensions
    {

        public static IQueryable<BlogPostGetAllOutputModel> OrderByFilter(this IQueryable<BlogPostGetAllOutputModel> query, string sorting)
        {
            switch (sorting)
            {
                case "asc":
                    return query.OrderBy(x => x.CreationDate);
                case "desc":
                    return query.OrderByDescending(x => x.CreationDate);
                default:
                    return query;
            }
        }

        public static IQueryable<BlogPostGetAllOutputModel> ApplyCategoryFilter(
            this IQueryable<BlogPostGetAllOutputModel> query, string[] categories)
        {
            if (categories == null)
                return query;

            query = query.Where(x => x.Categories.Any(y => categories.Contains(y.SafeName)));

            return query;
        }

        public static IQueryable<BlogPostGetAllOutputModel> ApplyTagFilter(
            this IQueryable<BlogPostGetAllOutputModel> query, string[] tags)
        {
            if (tags == null)
                return query;

            query = query.Where(x => x.Tags.Any(y => tags.Contains(y.Text)));
            return query;
        }
    }
}
