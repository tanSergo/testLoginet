using Microsoft.AspNetCore.Mvc;
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

        // GET api/values
        [HttpGet]
        public User[] GET()
        {
            return _usersService.getAllUsers();
        }
    }
}