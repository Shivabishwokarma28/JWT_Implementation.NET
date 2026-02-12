namespace JWT_Implementation.Model
{
    // Represents an Employee entity in the system
    // This class will be mapped to the Employees table in the database
    public class Employee
    {
        // Primary Key of the Employee table
        public int Id { get; set; }

        // Name of the employee
        public string Name { get; set; }

        // Job title or position of the employee
        public string Designation { get; set; }

        // Company where the employee works
        public string Company { get; set; }
    }
}
