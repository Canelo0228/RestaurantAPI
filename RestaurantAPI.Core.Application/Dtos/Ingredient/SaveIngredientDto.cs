using System.Text.Json.Serialization;

namespace RestaurantAPI.Core.Application.Dtos.Ingredient
{
    public class SaveIngredientDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
