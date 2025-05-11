using EmployeeFullStack.Data;
using EmployeeFullStack.Models;
using EmployeeFullStack.Models.DTOs;
using EmployeeFullStack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFullStack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employeesList = _employeeService.GetAll();
            if (employeesList == null || !employeesList.Any())
                return NotFound("No employees found.");

            return Ok(employeesList);
        }

        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> Get(Guid id)
        {
            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound("This id is not associated with any eployee in DB.");

            return employee;
        }
        // POST action
        [Authorize]
        [HttpPost("protected")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create(CreateEmployeeDto employee)
        {
            var createdEmployee = _employeeService.Add(employee); // Save and get entity with Id

            return CreatedAtAction(nameof(Get), new { id = createdEmployee.Id }, createdEmployee);
        }

        // PUT action
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Guid id, CreateEmployeeDto employee)
        {
            _employeeService.Update(id, employee);
            return Ok($"Employee '{employee.Name}' is updated successfully in DB.");
        }

        // DELETE action
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var employee = _employeeService.GetById(id);

            if (employee is null)
                return NotFound();

            _employeeService.Delete(id);
            return Ok($"Employee '{employee.Name}' is deleted successfully from DB.");
        }

        [HttpGet("exception")]
        public IActionResult ThrowException()
        {
            throw new Exception("This is a test exception");
        }

    }
}
