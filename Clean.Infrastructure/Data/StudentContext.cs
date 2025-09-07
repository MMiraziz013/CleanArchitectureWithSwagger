using Clean.Application.Abstractions;
using Clean.Infrastructure.Models;
using Dapper;

namespace Clean.Infrastructure.Data;

public class StudentContext : IStudentContext
{
    private readonly IAppDbContext _context;

    public StudentContext(IAppDbContext context)
    {
        _context = context;
    }

    public bool Add(Student student)
    {
        using var conn = _context.GetConnection();
        var sql = "insert into students(fullname, age) values (@FullName, @Age)";
        var isAdded = conn.Execute(sql, student);
        return isAdded == 1;
    }

    public List<Student> GetAll()
    {
        using var conn = _context.GetConnection();
        var sql = "select id as Id, fullname as FullName, age as Age from students order by id";
        var list = conn.Query<Student>(sql).ToList();
        return list;
    }

    public Student GetById(int id)
    {
        using (var conn = _context.GetConnection())
        {
            var sql = "select id as Id, fullname as FullName, age as Age from students where id = @Id";
            var student = conn.QueryFirstOrDefault<Student>(sql, new { Id = id });

            return student;
        }
    }

    public bool Update(Student student)
    {
        using (var conn = _context.GetConnection())
        {
            var sql = "update students set fullname = @FullName, age = @Age where id = @Id";
            var isUpdated = conn.Execute(sql, student);
            return isUpdated == 1;
        }
    }

    public bool Delete(int id)
    {
        using (var conn = _context.GetConnection())
        {
            var sql = "delete from students where id = @Id";
            var isDeleted = conn.Execute(sql, new { Id = id });
            return isDeleted == 1;
        }
    }
}