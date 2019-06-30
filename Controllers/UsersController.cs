using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<User> Get()
        {
            User[] users = _usersService.getAllUsers();

            if (users == null)
                return Enumerable.Empty<User>();

            return users;
        }

        // Получение пользователя по id
        // GET api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<User> Get(long id)
        {
            if (id < 0)
                return BadRequest();

            User user = _usersService.getUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // Получение всех альбомов одного пользователя
        // GET api/users/{id}/albums
        [HttpGet("{id}/albums")]
        public IEnumerable<Album> GetUsersAlbums(long id)
        {
            Album[] userAlbums = _usersService.getAlbumsByUserId(id);
            if (userAlbums == null)
                return Enumerable.Empty<Album>();

            return userAlbums;
        }
    }
}