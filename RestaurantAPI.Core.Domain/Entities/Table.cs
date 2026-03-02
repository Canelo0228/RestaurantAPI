using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Table : AuditableBaseEntity
    {
        public int Capability { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }

        public TableStatus TableStatus { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
