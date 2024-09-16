using System.Threading.Tasks;
using NyvaaSilksEcommerce.Models;

namespace NyvaaSilksEcommerce.Repositories
{
    
        public interface IUserRepository
        {
            Task<User> GetUserByEmailOrMobileAsync(string emailOrMobile);
            Task<int> CreateUserAsync(User user);
        }

    
}
