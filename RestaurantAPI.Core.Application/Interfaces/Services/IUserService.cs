using RestaurantAPI.Core.Application.Dtos.User;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
    }
}
