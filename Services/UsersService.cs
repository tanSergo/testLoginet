using Newtonsoft.Json;
using testLoginet.Controllers;
using testLoginet.Helpers;
using testLoginet.Models;
using testLoginet.Models.Interfaces;

namespace testLoginet.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersDao _userDao;
        private readonly IEncryptor _encryptor;

        public UsersService(IUsersDao usersDao, IEncryptor encryptor)
        {
            _userDao = usersDao;
            _encryptor = encryptor;
        }

        public User[] getAllUsers()
        {

            User[] users = JsonConvert.DeserializeObject<User[]>(_userDao.GetAllUsers());
            foreach (User u in users)
            {
                u.Email = _encryptor.EncryptString(u.Email);
            }
            return users;            
        }
    }
}
