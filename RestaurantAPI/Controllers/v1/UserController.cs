using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Core.Application.Dtos.User;
using RestaurantAPI.Core.Application.Interfaces.Services;
using System.Security.Claims;

namespace RestaurantAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response =  await _authService.Login(request);
            if (response == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok(response);
        }
    }
}
