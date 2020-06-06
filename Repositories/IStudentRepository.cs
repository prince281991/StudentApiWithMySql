using StudentApiWithMySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApiWithMySql.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int Id);
        Task<Student> PostStudent(Student student);
        Task<Student> PutStudent(Student student);
        Task DeleteStudent(int Id);
        Task<Student> StudentExists(int Id);
    }
}
