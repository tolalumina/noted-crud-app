using Microsoft.Data.SqlClient;
using System.Data;

namespace NotedApp.Api.Data
{
    public class NotedDbContext
    {
        private readonly string _connectionString;

        public NotedDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                                ?? throw new InvalidOperationException("DB Connection string not found.");
        }

        // Helper method to create a new connection
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}