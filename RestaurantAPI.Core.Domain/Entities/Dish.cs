using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Dish : AuditableBaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ServesPeople { get; set; }
        public ICollection<DishIngredient> DishIngredients { get; set; }
        public string Category { get; set; }
    }
}
