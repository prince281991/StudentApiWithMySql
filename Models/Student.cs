using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApiWithMySql.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public long Contact { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public bool IsActive { get; set; }
    }
}
