# JWT_Implementation.NET
Step-by-step description
Click the raw button to increase readibility...
JWT Implementation API

A simple ASP.NET Core Web API project demonstrating JWT authentication and CRUD operations on an Employee resource using Entity Framework Core and SQL Server.

I. Project Structure
JWT_Implementation/
│
├── Controllers/
│   ├── AuthController.cs        // Handles login & user registration
│   └── EmployeeController.cs    // Handles CRUD operations for Employee
│
├── Data/
│   └── JWTDbContext.cs          // EF Core DbContext for Users & Employees
│
├── Interfaces/
│   ├── IAuthService.cs          // Interface for authentication service
│   └── IEmployeService.cs       // Interface for employee service
│
├── Model/
│   ├── User.cs                  // User entity
│   └── Employee.cs              // Employee entity
│
├── Request_Model/
│   └── LoginRequest.cs          // Login DTO for authentication
│
├── Services/
│   ├── AuthService.cs           // Handles JWT generation & user creation
│   └── EmployeeService.cs       // Handles CRUD operations for Employee
│
├── appsettings.json             // JWT and DB configuration
├── Program.cs                   // Configures DI, JWT, and middleware
└── README.md                    // Project documentation

II. Features

1. User Authentication
1.1 Register a new user (AddUser)
1.2 Login (Login) with JWT token generation

2. JWT Authorization
2.1 Protects all employee endpoints
2.2 Validates issuer, audience, and token signature

3. Employee CRUD
3.1 Get all employees
3.2 Get employee by ID
3.3 Add new employee
3.4 Update employee
3.5 Delete employee

4. Database
4.1 Uses SQL Server
4.2 Managed via Entity Framework Core

III. Setup / Installation

1. Update connection string

Edit appsettings.json:

"ConnectionStrings": {
  "dbcs": "Server=YOUR_SERVER;Database=JWTImplementation;Trusted_Connection=True;TrustServerCertificate=True;"
},
"Jwt": {
  "Key": "YOUR_SECRET_KEY",
  "Issuer": "YOUR_ISSUER",
  "Audience": "YOUR_AUDIENCE",
  "Subject": "JWT Authentication"
}


2. Install NuGet packages

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.Identity



3. Create database and apply migrations

add-migration updateidmig
update-database


4. Run the API:



Swagger UI will be available at https://localhost:{PORT}/swagger.

IV. API Endpoints

1. AuthController

No	Method	Route	Description
1	POST	/api/Auth/AddUser	Register a new user
2	POST	/api/Auth/Login	Login and receive JWT

2. EmployeeController (JWT Protected)

No	Method	Route	Description
1	GET	/api/Employee	Get all employees
2	GET	/api/Employee/{id}	Get employee by ID
3	POST	/api/Employee	Add a new employee
4	PUT	/api/Employee/{id}	Update an existing employee
5	DELETE	/api/Employee/{id}	Delete an employee by ID

Note: Include JWT token in Authorization header:
Authorization: Bearer {your_token_here}

V. Notes / Best Practices

1.Password Security: User passwords are hashed using PasswordHasher<User>.

2. Token Expiry: Default JWT expiration is 10 minutes.

3. Exception Handling: Simple exceptions for invalid credentials or missing employee records.

4. Dependency Injection: Services (AuthService, EmployeeService) registered using AddTransient.

5. EF Core: DbContext configured with SQL Server and DbSet<User> & DbSet<Employee>.

VI. References

1. ASP.NET Core Web API – Official documentation:
    https://learn.microsoft.com/aspnet/core/web-api

2. Entity Framework Core – Database and DbContext guide:
     https://learn.microsoft.com/ef/core/

3. JWT Authentication in ASP.NET Core – Microsoft guide:
     https://learn.microsoft.com/aspnet/core/security/authentication/jwt

4. Swagger / OpenAPI – API testing and documentation:
     https://swagger.io/docs/

5. Microsoft Identity / PasswordHasher – User authentication:
     https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.identity.passwordhasher-1

6. YouTube Tutorial – Tutorial followed for JWT:
