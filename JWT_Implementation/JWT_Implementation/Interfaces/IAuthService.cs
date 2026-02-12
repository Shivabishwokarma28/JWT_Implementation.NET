using JWT_Implementation.Model;
using JWT_Implementation.Request_Model;

namespace JWT_Implementation.Interfaces
{
    public interface IAuthService
    {
        User AddUser(User user);
        string Login(LoginRequest loginRequest);
    }
}
