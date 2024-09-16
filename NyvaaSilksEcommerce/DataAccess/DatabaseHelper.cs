using System.Data.SqlClient;

namespace NyvaaSilksEcommerce.DataAccess
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> ExecuteNonQueryAsync(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                await conn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<SqlDataReader> ExecuteQueryAsync(string query, SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);
            await conn.OpenAsync();
            return await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.CloseConnection);
        }

        public async Task<object> ExecuteScalarAsync(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                await conn.OpenAsync();
                return await cmd.ExecuteScalarAsync();
            }
        }
    }
}
