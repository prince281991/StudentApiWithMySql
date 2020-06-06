using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApiWithMySql.Repositories;
using StudentApiWithMySql.Models;
using Microsoft.AspNetCore.Cors;

namespace StudentApiWithMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudent(int Id)
        {
            var student = await _repository.GetStudent(Id);
            if (student != null)
            {
                return Ok(student);
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
                return Ok(student); //CreatedAtRoute("GetStudent", new { newStudent.Id }, newStudent);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutStudent(int Id,Student student)
        {
            var stydentexists = _repository.StudentExists(Id);
            if (stydentexists != null)
            {
                var newStudent = await _repository.PutStudent(student);
                return Ok(newStudent); //CreatedAtRoute("GetStudent", new { newStudent.Id }, newStudent);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var stydentexists = _repository.StudentExists(Id);
            if (stydentexists!=null)
            {
                 await _repository.DeleteStudent(Id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
