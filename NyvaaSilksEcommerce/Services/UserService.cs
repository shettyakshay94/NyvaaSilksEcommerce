using System.Threading.Tasks;
using NyvaaSilksEcommerce.Repositories;
using NyvaaSilksEcommerce.Models;
using BCrypt.Net;

using NyvaaSilksEcommerce.Services;

namespace NyvaaSilksEcommerce.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByEmailOrMobileAsync(string emailOrMobile)
        {
            return await _userRepository.GetUserByEmailOrMobileAsync(emailOrMobile);
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            int result = await _userRepository.CreateUserAsync(user);
            return result > 0;
        }
    }
}
