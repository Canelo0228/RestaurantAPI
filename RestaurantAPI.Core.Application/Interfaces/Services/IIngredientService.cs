using RestaurantAPI.Core.Application.Dtos.Ingredient;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IIngredientService : IGenericService<SaveIngredientDto, IngredientDto, Ingredient>
    {

    }
}
