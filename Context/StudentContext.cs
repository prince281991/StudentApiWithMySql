using Microsoft.EntityFrameworkCore;
using StudentApiWithMySql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApiWithMySql.Context
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base()
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
