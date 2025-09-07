namespace Clean.Infrastructure.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }

    public void Greeting()
    {
        Console.WriteLine($"Hello my name is {FullName}");
    }
}