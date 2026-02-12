using System.ComponentModel.DataAnnotations;

namespace JWT_Implementation.Model
{
    // Represents an application user for authentication
    public class User
    {
        // Primary Key (Auto-incremented by database)
        [Key]
        public int Id { get; set; }

        // Username for login
        [Required]
        public string UserName { get; set; } = string.Empty;

        // Email address
        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string UserEmail { get; set; } = string.Empty;

        // Hashed password
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
