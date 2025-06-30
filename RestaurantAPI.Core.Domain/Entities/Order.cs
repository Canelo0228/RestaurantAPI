using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Order : AuditableBaseEntity
    {
        public int TableId { get; set; }
        public Table Table { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; } = "InProcess";
    }
}
