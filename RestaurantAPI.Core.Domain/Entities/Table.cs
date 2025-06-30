using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Table : AuditableBaseEntity
    {
        public int Capability { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Available";
        public ICollection<Order> Orders { get; set; }
    }
}
