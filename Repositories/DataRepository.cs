using Npgsql;
using Microsoft.Extensions.Configuration;
using NLog;
namespace CsvProcessor.Repositories
{
    public class DataRepository
    {
        private readonly string _connectionString;

        public DataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task InsertRecord(int id, string name, int age, string email, string code, bool isValidEmail)
        {
           
             using var conn = new NpgsqlConnection(_connectionString);
             conn.Open();

            var cmd = new NpgsqlCommand("INSERT INTO ProcessedRecords (id, name, age, email, code, isvalidemail) VALUES (@id, @name, @age, @email, @code, @isValidEmail)", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("age", age);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("code", code);
            cmd.Parameters.AddWithValue("isvalidemail", isValidEmail);
           
            cmd.ExecuteNonQuery();
            
        }
    }
}
