using EmpTest.Data;
using EmpTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserDbContext _context;

        public LoginController(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var userdetail = _context.users.AsQueryable();
            return Ok(userdetail);
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.users.Add(userObj);
                _context.SaveChanges();
                return Ok(
                    new
                    {
                        StatusCode = 200,
                        Message = "User added successfully"

                    });

            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User userObj)
        {
            if(userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _context.users.Where(e => e.UserName == userObj.UserName && e.Password == userObj.Password).FirstOrDefault();
                if(user != null)
                {
                    return Ok(
                        new
                        {
                            StatusCode = 200,
                            Message = "User Logged in successfully"
                        });
                }
                else
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }
            }
        }
    }
}