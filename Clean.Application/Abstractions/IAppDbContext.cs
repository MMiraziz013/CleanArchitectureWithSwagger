using System.Data;

namespace Clean.Application.Abstractions;

public interface IAppDbContext
{
    IDbConnection GetConnection();
}