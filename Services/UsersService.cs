using Newtonsoft.Json;
using testLoginet.Controllers;
using testLoginet.Helpers;
using testLoginet.Models;
using testLoginet.Models.Interfaces;

namespace testLoginet.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersDao _usersDao;
        private readonly IEncryptor _encryptor;

        public UsersService(IUsersDao usersDao, IEncryptor encryptor)
        {
            _usersDao = usersDao;
            _encryptor = encryptor;
        }

        public User[] getAllUsers()
        {
            string usersJson = _usersDao.GetAllUsers();

            if (usersJson == null)
            {
                return null;
            }

            User[] users = JsonConvert.DeserializeObject<User[]>(usersJson);
            foreach (User u in users)
            {
                u.Email = _encryptor.EncryptString(u.Email);
            }
            return users;            
        }

        public User getUserById(long id)
        {
            string userJson = _usersDao.GetUserById(id);

            if (userJson == null)
                return null;

            User user = JsonConvert.DeserializeObject<User>(userJson);
            user.Email = _encryptor.EncryptString(user.Email);
            return user;
        }

        public Album[] getAlbumsByUserId(long id)
        {
            string userAlbumsJson = _usersDao.getAlbumsByUserId(id);
            if (userAlbumsJson == null)
                return null;

            return JsonConvert.DeserializeObject<Album[]>(userAlbumsJson);

        }
    }
}
