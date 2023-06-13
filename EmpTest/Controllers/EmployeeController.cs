using EmpTest.Data;
using EmpTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly UserDbContext _context;

        public EmployeeController(UserDbContext context)
        {
            _context = context;
        }


        [HttpPost("add_employee")]
        public IActionResult AddEmployee([FromBody] Employee empObj)
        {
            if (empObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.employees.Add(empObj);
                _context.SaveChanges();
                return Ok(
                    new
                    {
                        StatusCode = 200,
                        Message = "Employee Added successfully"
                    });
            }
        }


        [HttpPut("update_employee")]
        public IActionResult UpdateEmployee([FromBody] Employee empObj)
        {
            if (empObj == null)
            {
                return BadRequest();
            }
            else
            {
                var emp = _context.employees.AsNoTracking().FirstOrDefault(e => e.Id == empObj.Id);
                if (emp == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Employee Not found"
                    });

                }
                else
                {
                    _context.Entry(empObj).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Employee updated successfully"
                    });
                }
            }
        }

        [HttpDelete("delete_employee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = _context.employees.Find(id);
            if(emp == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Employee not found"
                });

            }
            else
            {
                _context.employees.Remove(emp);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Employee Deletd Successfully"
                });
            }
        }

        [HttpGet("get_all_employee")]
        public IActionResult GetAllEmployee()
        {
            var emp = _context.employees.AsQueryable();
            return Ok(new
            {
                StatusCode = 200,
                EmployeeDetails = emp
            });
        }

        [HttpGet("get_employee/id")]
        public IActionResult GetEmployee(int id)
        {
            var emp = _context.employees.Find(id);
            if(emp == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Employee not found"
                });

            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    EmployeeDetails = emp
                });
            }
        }


    }
}

    
