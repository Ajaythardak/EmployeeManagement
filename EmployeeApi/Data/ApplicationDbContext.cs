using EmployeeFullStack.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFullStack.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<User> Users => Set<User>();
    }
}
