using JWT_Implementation.Interfaces;
using JWT_Implementation.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Implementation.Controllers
{
    // Controller to handle employee-related API endpoints
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // All endpoints require JWT authentication
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeService employeeService; // Injected employee service

        public EmployeeController(IEmployeService employeeService)
        {
            this.employeeService = employeeService; // Initialize service through DI
        }

        // ==============================
        // GET: api/Employee
        // Returns a list of all employees
        // ==============================
        [HttpGet]
        public List<Employee> Get()
        {
            var employees = employeeService.GetEmployeeDetails();
            return employees;
        }

        // ==============================
        // GET: api/Employee/{id}
        // Returns a single employee by ID
        // ==============================
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var emp = employeeService.GetEmployeeDetails(id);
            return emp;
        }

        // ==============================
        // POST: api/Employee
        // Adds a new employee
        // ==============================
        [HttpPost]
        public Employee Post([FromBody] Employee employee)
        {
            var emp = employeeService.AddEmployee(employee);
            return emp;
        }

        // ==============================
        // PUT: api/Employee/{id}
        // Updates an existing employee
        // ==============================
        [HttpPut("{id}")]
        public Employee Put(int id, [FromBody] Employee employee)
        {
            // Note: The ID parameter is not used because the Employee object already has the ID
            var emp = employeeService.UpdateEmployee(employee);
            return emp;
        }

        // ==============================
        // DELETE: api/Employee/{id}
        // Deletes an employee by ID
        // ==============================
        [HttpDelete("{id}")]
        public Employee Delete(int id)
        {
            var delemp = employeeService.DeleteEmployee(id);
            return delemp;
        }
    }
}
