using System.Text.Json.Serialization;

namespace RestaurantAPI.Core.Application.Dtos.Dish
{
    public class SaveDishDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ServesPeople { get; set; }
        public List<int> IngredientIds { get; set; }
        public int Category { get; set; }
    }
}
