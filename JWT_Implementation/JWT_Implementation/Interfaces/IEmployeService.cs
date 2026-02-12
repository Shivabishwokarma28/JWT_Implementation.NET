using JWT_Implementation.Model;

namespace JWT_Implementation.Interfaces
{
    // Interface for employee management services
    public interface IEmployeService
    {
        // Returns a list of all employees
        List<Employee> GetEmployeeDetails();

        // Returns details of a single employee by ID
        Employee GetEmployeeDetails(int id);

        // Adds a new employee
        Employee AddEmployee(Employee employee);

        // Deletes an employee by ID
        Employee DeleteEmployee(int id);

        // Updates an existing employee
        Employee UpdateEmployee(Employee emp);
    }
}
