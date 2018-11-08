using System.Threading.Tasks;
using SametKabay.Application.UserServices.Dto;

namespace SametKabay.Application.UserServices
{
    public interface IUserAppServices
    {
        Task<LoginOutputModel> Login(LoginInputModel input);

        Task CreateUser(CreateUserInputModel input);
    }
}