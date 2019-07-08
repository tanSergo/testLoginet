using Newtonsoft.Json;
using System.Threading.Tasks;
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

        public async Task<User[]> getAllUsersAsync()
        {
            string usersJson = await _usersDao.GetAllUsersAsync();

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

        public async Task<User> getUserByIdAsync(long id)
        {
            string userJson = await _usersDao.GetUserByIdAsync(id);

            if (userJson == null)
                return null;

            User user = JsonConvert.DeserializeObject<User>(userJson);
            user.Email = _encryptor.EncryptString(user.Email);
            return user;
        }

        public async Task<Album[]> getAlbumsByUserIdAsync(long id)
        {
            string userAlbumsJson = await _usersDao.getAlbumsByUserIdAsync(id);
            if (userAlbumsJson == null)
                return null;

            return JsonConvert.DeserializeObject<Album[]>(userAlbumsJson);

        }
    }
}
