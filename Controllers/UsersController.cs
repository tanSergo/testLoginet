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

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            User[] users = _usersService.getAllUsers();

            if (users == null)
                return Enumerable.Empty<User>();

            return users;
        }

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
    }
}