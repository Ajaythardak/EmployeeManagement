using EmployeeFullStack.Data;
using EmployeeFullStack.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFullStack.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
