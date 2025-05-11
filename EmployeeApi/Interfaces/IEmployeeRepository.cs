using EmployeeFullStack.Models;
using EmployeeFullStack.Models.DTOs;

namespace EmployeeFullStack.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(Guid id);
        Employee Add(CreateEmployeeDto employee);
        void Update(Guid id, CreateEmployeeDto employee);
        void Delete(Guid id);
        void Save();
    }
}
