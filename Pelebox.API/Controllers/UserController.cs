using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pelebox.Application.UseCases;
using Pelebox.Domain.Entities;
using System.Threading.Tasks;

namespace Pelebox.API.Controllers {

    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : LoggedInBaseController {

        private readonly UserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(UserService userService, ILogger<UserController> logger) {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get() => await _userService.GetUsers();

    }
}
