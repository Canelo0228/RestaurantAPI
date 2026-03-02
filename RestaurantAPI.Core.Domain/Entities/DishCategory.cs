using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class DishCategory : AuditableBaseEntity
    {
        public string Category { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}
