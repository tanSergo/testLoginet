using testLoginet.Models;

namespace testLoginet.Controllers
{
    public interface IUsersService
    {
        User[] getAllUsers();

        User getUserById(long id);
    }
}