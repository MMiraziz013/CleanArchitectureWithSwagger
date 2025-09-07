using Clean.Infrastructure.Models;

namespace Clean.Application.Abstractions;

public interface IStudentContext
{
    bool Add(Student student);
    List<Student> GetAll();

    Student GetById(int id);

    bool Update(Student student);

    bool Delete(int id);
}