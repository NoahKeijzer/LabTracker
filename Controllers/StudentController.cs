using Domain;
using DomainServices;
using DomainServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly IRepository<Student> _studentenRepository;

    public StudentController(ILogger<StudentController> logger, IRepository<Student> studentenRepository)
    {
        _logger = logger;
        _studentenRepository = studentenRepository;
    }

    [HttpGet(Name = "GetStudenten")]
    public IEnumerable<Student> Get()
    {
        return _studentenRepository.GetAll();
    }   
    [HttpGet(Name = "GetStudentenByID")]
    public Student GetByID(Guid id)
    {
        return _studentenRepository.Get(id);
    }
    [HttpPost(Name = "CreateStudent")]
    public Student Create([FromBody] Student student)
    {
        _studentenRepository.Create(student);
        return student;
    }
    [HttpDelete(Name = "DeleteStudent")]
    public void Delete([FromBody] Student student)
    {
        _studentenRepository.Delete(student);
    }
    [HttpPut(Name = "UpdateStudent")]
    public void Update([FromBody] Student student)
    {
        _studentenRepository.Update(student);
    }
}