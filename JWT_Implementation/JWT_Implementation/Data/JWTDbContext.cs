using Microsoft.EntityFrameworkCore;
using JWT_Implementation.Model;

namespace JWT_Implementation.Data
{
    // JWTDbContext is the main database context class
    // It manages entity objects and handles database operations
    public class JWTDbContext : DbContext
    {
        // Constructor to pass DbContext options (like connection string)
        // to the base DbContext class
        //DbContextOptions:
        // Connection string

        // Database provider(SQL Server, MySQL, etc.)
        //Other EF Core settings
        public JWTDbContext(DbContextOptions options) : base(options)
        {
        }

        // Users table representation in the database
        // This allows CRUD operations for User entity
        public DbSet<User> Users { get; set; }

        // Employees table representation in the database
        // This allows CRUD operations for Employee entity
        public DbSet<Employee> Employees { get; set; }
    }
}
