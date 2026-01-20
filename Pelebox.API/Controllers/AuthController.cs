using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pelebox.API.Models;
using Pelebox.API.Security;
using Pelebox.Application.UseCases;

namespace Pelebox.API.Controllers {
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : Controller {
        private readonly ILogger<AuthController> _logger;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly UserService _userService;

        public AuthController(ILogger<AuthController> logger, IJwtAuthenticationManager jwtAuthenticationManager, UserService userService) {
            _logger = logger;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string email,string password) {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password)) {
                return Ok(new LoginResponse() { Status = LoginStatus.Invalid, Message = "Invalid Credentials!" });
            }

            try {
                var user = await _userService.UserValidate(email,password);

                if (user != null && user?.UserId > 0) {

                    if (user.IsActive == true && user.IsAdmin == true) {
                        var token = _jwtAuthenticationManager.Authenticate(user.UserId.ToString(), user.Email, user.FirstName, user.LastName);

                        if (token != null) {
                            LoginResponse loginResponse = new() {
                                AccessToken = token,
                                User = user,
                                Status = LoginStatus.Success,
                                Message = "Success"
                            };

                            return Ok(loginResponse);
                        } else {
                            return Ok(new LoginResponse() { Status = LoginStatus.Invalid, Message = "Invalid user request!" });
                        }
                    } else if (user.IsActive == true && user.IsAdmin == false) {
                        return Ok(new LoginResponse() { Status = LoginStatus.Invalid, Message = "User is not Admin!" });
                    } else
                        return Ok(new LoginResponse() { Status = LoginStatus.Invalid, Message = "User is Inactive!" });
                } else {
                    return Ok(new LoginResponse() { Status = LoginStatus.Invalid, Message = "User is not present in the system!" });
                }
            } catch (System.Exception ex) {
                _logger.LogError(ex.Message + "," + ex.InnerException?.Message);
                return Ok(new LoginResponse() { Status = LoginStatus.Invalid, Message = ex.Message });
            }
        }
    }
}