using ApplicationLayer.Contracts;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository student;
        public StudentController(IStudentRepository student)
        {
            this.student = student;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await student.GetAsync();
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Student student)
        {
            var result = await this.student.AddAsync(student);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            var result = await this.student.DeleteAsync(id);   
            return Ok(result);  
        }
    }

}
