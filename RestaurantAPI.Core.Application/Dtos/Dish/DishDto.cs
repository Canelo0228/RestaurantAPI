using RestaurantAPI.Core.Application.Dtos.Ingredient;

namespace RestaurantAPI.Core.Application.Dtos.Dish
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ServesPeople { get; set; }
        public List<IngredientDto> Ingredients { get; set; }
        public string Category { get; set; }
    }
}
