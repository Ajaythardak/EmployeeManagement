using EmployeeFullStack.Data;
using EmployeeFullStack.Interfaces;
using EmployeeFullStack.Models;
using EmployeeFullStack.Models.DTOs;
using EmployeeFullStack.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeFullStack.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Employee GetById(Guid id)
        {
            return _employeeRepository.GetById(id);
        }

        public Employee Add(CreateEmployeeDto newEmployee)
        {
            return _employeeRepository.Add(newEmployee);
        }

        public void Delete(Guid id)
        {
            _employeeRepository.Delete(id);
        }

        public void Update(Guid id, CreateEmployeeDto employee)
        {
            _employeeRepository.Update(id, employee);
        }
    }
}
