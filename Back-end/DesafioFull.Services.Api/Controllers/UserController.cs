using DesafioFull.Application.Services;
using DesafioFull.Application.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DesafioFull.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _config;
        private readonly UserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IConfiguration config,
            UserService userService
            )
        {
            _logger = logger;
            _config = config;
            _userService = userService;
        }

        /// <summary>
        /// Method responsible to authenticate users in Api
        /// </summary>
        /// <param name="userViewModel">Email and Password</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserViewModel userViewModel)
        {
            try
            {
                UserResponseViewModel userResponse = await _userService.Authenticate(userViewModel);
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
