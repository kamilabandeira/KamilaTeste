using KT.Data.Repositories.Interface;
using KT.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GEt()
        {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student)
        {
            await _repository.Add(student);
            return StatusCode(201);
        }

        [HttpPut("{idAluno}")]
        public async Task<IActionResult> Put(int idAluno, Student student)
        {
            await _repository.Update(idAluno, student);
            return NoContent();
        }

        [HttpDelete("{idAluno}")]
        public async Task<IActionResult> Delete(int idAluno)
        {
            await _repository.Delete(idAluno);
            return NoContent();
        }
    }
}
