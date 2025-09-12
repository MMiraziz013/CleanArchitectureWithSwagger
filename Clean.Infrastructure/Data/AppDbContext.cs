using System.Data;
using Clean.Application.Abstractions;
using Clean.Infrastructure.Models;
using Npgsql;

namespace Clean.Infrastructure.Data;

public class AppDbContext : IAppDbContext
{
     private string _connectionString =
         "YOUR CONNECTION STRING";
    
    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
