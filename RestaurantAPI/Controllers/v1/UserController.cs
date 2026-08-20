using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Dtos.User;
using RestaurantAPI.Core.Application.Interfaces.Services;

namespace RestaurantAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UserController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response =  await _authService.Login(request);
            
            if (response == null)
            {
                return Unauthorized("Invalid username or password.");
            
            }
            return Ok(response);
        }

        [HttpPost("register-waiter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponse))]
        public async Task<IActionResult> RegisterWaiter(RegisterRequest request)
        {
            var result = await _userService.AddAsync(request);

            return Ok(result);
        }
    }
}
