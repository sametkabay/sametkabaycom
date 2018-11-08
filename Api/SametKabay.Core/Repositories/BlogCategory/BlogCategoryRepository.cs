namespace SametKabay.Core.Repositories.BlogCategory
{
    public class BlogCategoryRepository:Repository<Models.BlogCategory>,IBlogCategoryRepository
    {
        public BlogCategoryRepository(SametKabayDbContext context) : base(context)
        {
        }
    }
}
