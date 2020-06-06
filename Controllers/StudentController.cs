using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApiWithMySql.Repositories;
using StudentApiWithMySql.Models;

namespace StudentApiWithMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        public StudentController(IStudentRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repository.GetStudents();
            if (students.Count() > 0)
            {
                return Ok(students);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(Student student)
        {
            if (ModelState.IsValid)
            {
               var newStudent= await _repository.PostStudent(student);
                return CreatedAtRoute("Get", new { newStudent.Id }, newStudent);
            }
            else
            {
                return BadRequest();
            }

            
        }
    }
}
