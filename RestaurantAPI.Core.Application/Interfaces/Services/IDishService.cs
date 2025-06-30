using RestaurantAPI.Core.Application.Dtos.Dish;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IDishService : IGenericService<SaveDishDto, DishDto, Dish>
    {
        Task<List<DishDto>> GetAllWithIncludesDto();
        Task<DishDto> GetByIdWithIncludesDto(int id);
    }
}
