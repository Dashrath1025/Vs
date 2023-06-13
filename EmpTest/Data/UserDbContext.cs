using EmpTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpTest.Data
{
    public class UserDbContext:DbContext

    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {

        }

        public DbSet<Employee> employees { get; set; } 
        public DbSet<User> users { get; set; } 
    }
}
