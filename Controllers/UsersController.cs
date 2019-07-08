using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testLoginet.Models;

namespace testLoginet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // Получение списка все пользователей
        // GET api/users
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            User[] users = await _usersService.getAllUsersAsync();

            if (users == null)
                return Enumerable.Empty<User>();

            return users;
        }

        // Получение пользователя по id
        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(long id)
        {
            if (id < 0)
                return BadRequest();

            User user = await _usersService.getUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // Получение всех альбомов одного пользователя
        // GET api/users/{id}/albums
        [HttpGet("{id}/albums")]
        public async Task<IEnumerable<Album>> GetUsersAlbumsAsync(long id)
        {
            Album[] userAlbums = await _usersService.getAlbumsByUserIdAsync(id);
            if (userAlbums == null)
                return Enumerable.Empty<Album>();

            return userAlbums;
        }
    }
}