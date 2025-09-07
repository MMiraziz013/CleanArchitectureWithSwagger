using Clean.Infrastructure.Models;

namespace Clean.Application.Services;

public interface IStudentService
{
    List<Student> GetStudents();

    Student GetById(int id);

    bool AddStudent(Student student);
    
    bool UpdateStudent(Student student);
    bool DeleteStudent(int id);
}