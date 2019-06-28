using Newtonsoft.Json;
using testLoginet.Controllers;
using testLoginet.Models;
using testLoginet.Models.Interfaces;

namespace testLoginet.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersDao _userDao;

        public UsersService(IUsersDao usersDao)
        {
            _userDao = usersDao;
        }

        public User[] getAllUsers()
        {

            User[] users = JsonConvert.DeserializeObject<User[]>(_userDao.GetAllUsers());
            
            return users;            
        }
    }
}
