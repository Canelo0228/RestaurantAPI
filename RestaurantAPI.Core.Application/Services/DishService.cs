using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Dish;
using RestaurantAPI.Core.Application.Dtos.Ingredient;
using RestaurantAPI.Core.Application.Enums;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Services
{
    public class DishService : GenericService<SaveDishDto, DishDto, Dish>, IDishService
    {
        private readonly IDishRepository _repository;
        private readonly IMapper _mapper;
        public DishService(IDishRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DishDto>> GetAllWithIncludesDto()
        {
            var dishList = await _repository.GetAllWithIncludesAsync(new List<string> { "DishIngredients.Ingredient" });

            return dishList.Select(dish => new DishDto()
            {
                Id = dish.Id,
                Category = Enum.TryParse<DishCategory>(dish.Category, ignoreCase: true, out var status)
                    ? status.ToString()
                    : "Unknown",
                Name = dish.Name,
                Ingredients = _mapper.Map<List<IngredientDto>>(
                    dish.DishIngredients.Select(di => di.Ingredient).ToList()
                ),
                Price = dish.Price,
                ServesPeople = dish.ServesPeople
            }).ToList();
        }

        public async Task<DishDto> GetByIdWithIncludesDto(int id)
        {
            var dish = await _repository.GetByIdWithIncludesAsync(id, new List<string> { "DishIngredients.Ingredient" });

            DishDto dto = new DishDto()
            {
                Id = dish.Id,
                Category = Enum.TryParse<DishCategory>(dish.Category, ignoreCase: true, out var status)
                    ? status.ToString()
                    : "Unknown",
                Name = dish.Name,
                Ingredients = _mapper.Map<List<IngredientDto>>(
                    dish.DishIngredients.Select(di => di.Ingredient).ToList()
                ),
                Price = dish.Price,
                ServesPeople = dish.ServesPeople
            };

            return dto;

        }

    }
}
