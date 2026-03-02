using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class OrderStatus : AuditableBaseEntity
    {
        public string Status { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
