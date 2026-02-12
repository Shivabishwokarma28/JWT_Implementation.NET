using JWT_Implementation.Data;
using JWT_Implementation.Interfaces;
using JWT_Implementation.Model;
using JWT_Implementation.Request_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Implementation.Services
{
    // Service for handling authentication (registering users and logging in)
    public class AuthService : IAuthService
    {
        private readonly JWTDbContext jwtservice; // Database context for accessing Users table
        private readonly IConfiguration configuration; // For reading JWT settings from appsettings.json

        public AuthService(JWTDbContext jwtservice, IConfiguration configuration)
        {
            this.jwtservice = jwtservice;
            this.configuration = configuration;
        }

        // Adds a new user to the database
        public User AddUser(User user)
        {
            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user,user.Password); //// Hash the password

            var addedUser = jwtservice.Users.Add(user); // Adds user to DbSet
            jwtservice.SaveChanges();                  // Saves changes to database
            return addedUser.Entity;                   // Returns the added user
        }

        // Logs in a user and returns a JWT token if credentials are valid
        public string Login(LoginRequest loginRequest)
        {
            // Basic null check for credentials
            if (loginRequest.UserName != null && loginRequest.Password != null)
            {
                // Look for user in the database
                var user = jwtservice.Users
                    .SingleOrDefault(s => s.UserName == loginRequest.UserName &&
                                          s.Password == loginRequest.Password);

                if (user != null)
                {
                    // Create JWT claims
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.UserEmail)
                    };

                    // Generate security key and signing credentials
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Create the JWT token
                    var token = new JwtSecurityToken(
                        issuer: configuration["Jwt:Issuer"],     // JWT issuer
                        audience: configuration["Jwt:Audience"], // JWT audience
                        claims: claims,                           // Claims defined above
                        expires: DateTime.UtcNow.AddMinutes(10), // Token expiry
                        signingCredentials: signIn
                    );

                    // Return token as string
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    // User not found
                    throw new Exception("User is not valid");
                }
            }
            else
            {
                // Credentials missing
                throw new Exception("Credentials are not valid");
            }
        }
    }
}
