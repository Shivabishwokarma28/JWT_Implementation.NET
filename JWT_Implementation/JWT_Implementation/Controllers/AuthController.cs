using JWT_Implementation.Interfaces;
using JWT_Implementation.Model;
using JWT_Implementation.Request_Model;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Implementation.Controllers
{
    // Controller to handle authentication-related API endpoints
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService; // Injected authentication service

        public AuthController(IAuthService authService)
        {
            this.authService = authService; // Initialize service through dependency injection
        }

        // ==============================
        // Login endpoint
        // POST: api/Auth/Login
        // ==============================
        [HttpPost("Login")]
        public string Login([FromBody] LoginRequest loginModel)
        {
            // Calls the AuthService to validate credentials and generate JWT token
            var result = authService.Login(loginModel);
            return result;
        }

        // ==============================
        // AddUser endpoint
        // POST: api/Auth/AddUser
        // ==============================
        [HttpPost("AddUser")]
        public User AddUser([FromBody] User val)
        {
            // Calls the AuthService to add a new user to the database
            var user = authService.AddUser(val);
            return user;
        }
    }
}
