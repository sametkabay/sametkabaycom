namespace SametKabay.Core.Repositories.User
{
    public class UserRepository:Repository<Models.User>,IUserRepository
    {
        public UserRepository(SametKabayDbContext context) : base(context)
        {
        }
    }
}
