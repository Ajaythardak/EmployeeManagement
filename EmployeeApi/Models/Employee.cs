using System.ComponentModel.DataAnnotations;

namespace EmployeeFullStack.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
