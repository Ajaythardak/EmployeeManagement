using EmployeeFullStack.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFullStack.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
