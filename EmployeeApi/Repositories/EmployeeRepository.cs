using EmployeeFullStack.Data;
using EmployeeFullStack.Interfaces;
using EmployeeFullStack.Models;
using EmployeeFullStack.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFullStack.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees
                .AsNoTracking()
                .ToList();
        }

        public Employee GetById(Guid id)
        {
            return _context.Employees
                .AsNoTracking()
                .SingleOrDefault(e => e.Id.Equals(id));
        }

        public Employee Add(CreateEmployeeDto newEmployee)
        {
            var employee = new Employee
            {
                Name = newEmployee.Name,
                EmailId = newEmployee.EmailId,
                Address = newEmployee.Address,
                PhoneNumber = newEmployee.PhoneNumber,
            };
            _context.Employees.Add(employee);
            Save();
            return employee;
        }

        public void Delete(Guid id)
        {
            var employeeToDelete = _context.Employees.Find(id);
            if (employeeToDelete is not null)
            {
                _context.Employees.Remove(employeeToDelete);
                Save();
            }
        }

        public void Update(Guid id, CreateEmployeeDto employeeToUpdate)
        {
            var existingEmployee = _context.Employees.Find(id);

            if (existingEmployee is null)
            {
                throw new InvalidOperationException("Employee does not exist");
            }

            existingEmployee.Name = !string.IsNullOrEmpty(employeeToUpdate.Name) && !employeeToUpdate.Name.Equals("string") ? employeeToUpdate.Name : existingEmployee.Name;
            existingEmployee.EmailId = !string.IsNullOrEmpty(employeeToUpdate.EmailId) && !employeeToUpdate.EmailId.Equals("string") ? employeeToUpdate.EmailId : existingEmployee.EmailId;
            existingEmployee.Address = !string.IsNullOrEmpty(employeeToUpdate.Address) && !employeeToUpdate.Address.Equals("string") ? employeeToUpdate.Address : existingEmployee.Address;
            existingEmployee.PhoneNumber = !string.IsNullOrEmpty(employeeToUpdate.PhoneNumber) && !employeeToUpdate.PhoneNumber.Equals("string") ? employeeToUpdate.PhoneNumber : existingEmployee.PhoneNumber;
            Save();
        }

        public void Save() => _context.SaveChanges();
    }
}
