using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpTest.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        
        public int Mobile { get; set; }
        public double Salary { get; set; }
    }
}
