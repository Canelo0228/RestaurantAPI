using RestaurantAPI.Core.Application.Dtos.User;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
