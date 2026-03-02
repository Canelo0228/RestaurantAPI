using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class TableStatus : AuditableBaseEntity
    {
        public string Status { get; set; }

        public ICollection<Table> Tables { get; set; }
    }
}
