using JWT_Implementation.Data;
using JWT_Implementation.Interfaces;
using JWT_Implementation.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JWT_Implementation.Services
{
    // Service class that implements employee-related operations
    public class EmployeeService : IEmployeService
    {
        private readonly JWTDbContext jwtContext; // Database context for accessing Employees table

        public EmployeeService(JWTDbContext jwtContext)
        {
            this.jwtContext = jwtContext; // Injected DbContext
        }

        // Adds a new employee to the database
        public Employee AddEmployee(Employee employee)
        {
            var emp = jwtContext.Add(employee); // Add employee to DbSet
            jwtContext.SaveChanges();           // Persist changes to DB
            return emp.Entity;                  // Return the added employee
        }

        // Deletes an employee by ID
        public Employee DeleteEmployee(int id)
        {
            // Find the employee by ID
            var emp = jwtContext.Employees.SingleOrDefault(s => s.Id == id);
            if (emp == null)
            {
                throw new Exception("User Not Found"); // Throw if employee doesn't exist
            }

            jwtContext.Employees.Remove(emp); // Remove employee
            jwtContext.SaveChanges();         // Persist changes
            return emp;                       // Return deleted employee
        }

        // Returns a list of all employees
        public List<Employee> GetEmployeeDetails()
        {
            var employee = jwtContext.Employees.ToList(); // Fetch all employees
            return employee;
        }

        // Returns a single employee by ID (async)
        public async Task<Employee> GetEmployeeDetails(int id)
        {
            var emp = await jwtContext.Employees.FindAsync(id); // Find employee asynchronously
            if (emp == null)
            {
                return NotFound(); // Call NotFound helper if not found
            }
            return emp;
        }

        // Helper method for returning not found (currently throws NotImplementedException)
        private Employee NotFound()
        {
            throw new NotImplementedException();
        }

        // Updates an existing employee
        public Employee UpdateEmployee(Employee emp)
        {
            var update = jwtContext.Employees.Update(emp); // Update employee in DbSet
            jwtContext.SaveChanges();                      // Persist changes
            return update.Entity;                          // Return updated employee
        }

        // Explicit interface implementation (not currently implemented)
        Employee IEmployeService.GetEmployeeDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
