using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Dish : AuditableBaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ServesPeople { get; set; }
        public int DishCategoryId { get; set; }

        public DishCategory DishCategory { get; set; }
        public ICollection<DishOrder> DishOrders { get; set; }
        public ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
