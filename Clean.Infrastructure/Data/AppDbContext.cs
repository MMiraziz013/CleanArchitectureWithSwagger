using System.Data;
using Clean.Application.Abstractions;
using Clean.Infrastructure.Models;
using Npgsql;

namespace Clean.Infrastructure.Data;

public class AppDbContext : IAppDbContext
{
    private string _connectionString = "Server=localhost; Port=5432;Database=students_db;User Id=postgres; Password=Mm1311Scorpio$";
    
    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}