using Microsoft.AspNetCore.Mvc;
using System.Net;
using Clean.Application.Abstractions;
using System.ComponentModel.DataAnnotations;
using Clean.Application.Services;
using Clean.Infrastructure.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
// Use ApiExplorerSettings to change the name of the group in Swagger UI.
public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    // GET
    [HttpGet]
    public IActionResult Index()
    {

        return Ok(_studentService.GetStudents());
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        return Ok(_studentService.GetById(id));
    }

    // POST
    [HttpPost(Name = "AddStudent")]
    public IActionResult Add(Student student)
    {
        return Ok(_studentService.AddStudent(student));
    }

    // PUT
    [HttpPut(Name = "UpdateStudent")]
    public IActionResult Update(Student student)
    {
        return Ok(_studentService.UpdateStudent(student));
    }

    // DELETE
    [HttpDelete(Name = "DeleteStudent")]
    public IActionResult Delete(int id)
    {
        return Ok(_studentService.DeleteStudent(id));
    }
}