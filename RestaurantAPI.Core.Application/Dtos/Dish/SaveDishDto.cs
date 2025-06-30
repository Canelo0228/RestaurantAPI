using RestaurantAPI.Core.Application.Enums;

namespace RestaurantAPI.Core.Application.Dtos.Dish
{
    public class SaveDishDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ServesPeople { get; set; }
        public List<int> IngredientIds { get; set; }
        public DishCategory Category { get; set; }
    }
}
