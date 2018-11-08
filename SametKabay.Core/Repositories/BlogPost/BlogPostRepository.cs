namespace SametKabay.Core.Repositories.BlogPost
{
    public class BlogPostRepository : Repository<Models.BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(SametKabayDbContext context) : base(context)
        {
        }
    }
}
