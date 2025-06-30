using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Ingredient : AuditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
