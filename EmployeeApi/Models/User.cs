using System.ComponentModel.DataAnnotations;

namespace EmployeeFullStack.Models
{
    public class User
    {
        [Key] // Mark this as the primary key
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
