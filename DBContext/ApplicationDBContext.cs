using Assignment_iVally.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_iVally.DBContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Salary> Salary { get; set; }

    }
}
