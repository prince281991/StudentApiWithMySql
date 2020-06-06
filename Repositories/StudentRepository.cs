using Microsoft.EntityFrameworkCore;
using StudentApiWithMySql.Context;
using StudentApiWithMySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApiWithMySql.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;
        public StudentRepository(StudentContext context)
        {
            _context = context;
        }
        public async Task DeleteStudent(int Id)
        {
            var existingStudent = await StudentExists(Id);
            if (existingStudent != null)
            {
                _context.Students.Remove(existingStudent);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudent(int Id)
        {
            return await _context.Students.FindAsync(Id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> PostStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> PutStudent(Student student)
        {
            var existingStudent= await StudentExists(student.Id);
            if(existingStudent!=null)
            {
                 _context.Entry(existingStudent).CurrentValues.SetValues(student);
                await _context.SaveChangesAsync();
                return student;
            }
            return student;
        }

        public async Task<Student> StudentExists(int Id)
        {
            return await _context.Students.FindAsync(Id);
        }
    }
}
