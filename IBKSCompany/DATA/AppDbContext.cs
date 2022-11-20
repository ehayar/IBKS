using IBKSCompany.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBKSCompany.DATA
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; } 

        public DbSet<Client> Client { get; set; }

        public DbSet<Branch> Branch { get; set; }
    }
}
