using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Dish;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Domain.Entities;
using System.Linq.Expressions;

namespace RestaurantAPI.Core.Application.Services
{
    public class DishService : GenericService<SaveDishDto, DishDto, Dish>, IDishService
    {
        private readonly IDishRepository _repository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;
        public DishService(IDishRepository repository, IIngredientRepository ingredientRepository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<List<DishDto>> GetAllWithIncludesAsync()
        {
            var dishes = await _repository.GetAllWithIncludeAsync(new List<string>
            {
                "DishCategory",
                "DishIngredients.Ingredient"
            });

            return _mapper.Map<List<DishDto>>(dishes);
        }

        public override async Task<DishDto> AddAsync(SaveDishDto dto)
        {
            var existingIngredients = await _ingredientRepository.GetAllAsync();
            var existingIds = existingIngredients.Select(i => i.Id).ToList();
            var missingIds = dto.IngredientIds.Where(id => !existingIds.Contains(id)).ToList();
            if (missingIds.Any())
            {
                throw new Exception("Ingredients don't exists");
            }

            Dish dish = _mapper.Map<Dish>(dto);
            dish.DishIngredients = new List<DishIngredient>();
            foreach (int ingredientId in dto.IngredientIds)
            {
                dish.DishIngredients.Add(new DishIngredient
                {
                    IngredientId = ingredientId
                });
            }
            await _repository.AddAsync(dish);
            return _mapper.Map<DishDto>(dish);
        }

        public override async Task UpdateAsync(SaveDishDto dto, int id)
        {
            var dish = await _repository.GetByIdWithIncludesAsync(id, new List<string> { "DishIngredients" });

            if (dish == null) return;

            _mapper.Map(dto, dish);

            dish.DishIngredients.Clear();

            foreach (var ingredientId in dto.IngredientIds)
            {
                dish.DishIngredients.Add(new DishIngredient
                {
                    DishId = id,
                    IngredientId = ingredientId
                });
            }

            await _repository.UpdateAsync(dish, id);
        }

        public async Task<DishDto> GetByIdWithIncludesAsync(int id)
        {
            var includes = new List<string>
            {
                "DishCategory",
                "DishIngredients.Ingredient"
            };
            var dish = await _repository.GetByIdWithIncludesAsync(id, includes);

            if (dish == null) return null;

            return _mapper.Map<DishDto>(dish);
        }
    }
}
