using Clean.Application.Abstractions;
using Clean.Infrastructure.Models;

namespace Clean.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentContext _context;

    public StudentService(IStudentContext context)
    {
        _context = context;
    }
    
    public List<Student> GetStudents()
    {
        return _context.GetAll();
    }

    public Student GetById(int id)
    {
        var st = _context.GetById(id);
        if (st is null)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "No student with the id: " + id);
        }

        return st;

    }

    public bool AddStudent(Student student)
    {
        if (_context.Add(student))
        {
            Console.WriteLine($"Student with name {student.FullName} was added!");
            return true;
        }
        
        return false;
    }

    public bool UpdateStudent(Student student)
    {
        if (_context.Update(student))
        {
            Console.WriteLine($"Student with Id({student.Id}) was updated!");
            return true;
        }
        
        throw new ArgumentOutOfRangeException(nameof(student), "No such student to update in the database");
    }
    

    public bool DeleteStudent(int id)
    {
        if (_context.Delete(id))
        {
            Console.WriteLine($"Student with Id({id} was deleted)");
            return true;
        }

        throw new ArgumentOutOfRangeException(nameof(id), "No student to delete with the given ID: " + id);
    }
}