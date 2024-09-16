using NyvaaSilksEcommerce.Models;
using System.Threading.Tasks;

namespace NyvaaSilksEcommerce.Services
{
    public interface IUserService
    {
        Task<User> GetUserByEmailOrMobileAsync(string emailOrMobile);
        Task<bool> RegisterUserAsync(User user);
    }
}
