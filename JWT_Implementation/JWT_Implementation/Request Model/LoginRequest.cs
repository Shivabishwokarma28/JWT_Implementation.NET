namespace JWT_Implementation.Request_Model
{
    // Represents the data sent by a user when logging in
    public class LoginRequest
    {
        // Username provided by the user
        public string UserName { get; set; } = string.Empty;

        // Password provided by the user
        public string Password { get; set; } = string.Empty;
    }
}
