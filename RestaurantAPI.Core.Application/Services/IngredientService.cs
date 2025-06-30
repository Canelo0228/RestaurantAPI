using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Ingredient;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Services
{
    public class IngredientService : GenericService<SaveIngredientDto, IngredientDto, Ingredient>, IIngredientService
    {
        private readonly IGenericRepository<Ingredient> _repository;
        private readonly IMapper _mapper;

        public IngredientService(IGenericRepository<Ingredient> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
