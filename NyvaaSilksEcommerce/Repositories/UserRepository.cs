using NyvaaSilksEcommerce.DataAccess;
using NyvaaSilksEcommerce.Models;
using NyvaaSilksEcommerce.Repositories;
using System.Data.SqlClient;
using System.Threading.Tasks;
using NyvaaSilksEcommerce.Models;

namespace NyvaaSilksEcommerce.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public UserRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<User> GetUserByEmailOrMobileAsync(string emailOrMobile)
        {
            string query = "SELECT * FROM Users WHERE Email = @EmailOrMobile OR MobileNumber = @EmailOrMobile";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@EmailOrMobile", emailOrMobile)
            };

            using (SqlDataReader reader = await _dbHelper.ExecuteQueryAsync(query, parameters))
            {
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = (int)reader["UserId"],
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNumber = reader["MobileNumber"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        IsAdmin = (bool)reader["IsAdmin"]
                    };
                }
            }
            return null;
        }

        public async Task<int> CreateUserAsync(User user)
        {
            string query = "INSERT INTO Users (FullName, Email, MobileNumber, PasswordHash, IsAdmin) " +
                           "VALUES (@FullName, @Email, @MobileNumber, @PasswordHash, @IsAdmin)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@MobileNumber", user.MobileNumber),
                new SqlParameter("@PasswordHash", user.PasswordHash),
                new SqlParameter("@IsAdmin", user.IsAdmin)
            };
            return await _dbHelper.ExecuteNonQueryAsync(query, parameters);
        }
    }
}
