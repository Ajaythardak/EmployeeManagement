using EmployeeFullStack.Models;
using EmployeeFullStack.Models.DTOs;

namespace EmployeeFullStack.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(Guid id);
        Employee Add(CreateEmployeeDto employeeDto);
        void Update(Guid id, CreateEmployeeDto employeeDto);
        void Delete(Guid id);
    }
}
