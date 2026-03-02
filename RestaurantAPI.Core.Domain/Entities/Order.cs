using RestaurantAPI.Core.Domain.Common;

namespace RestaurantAPI.Core.Domain.Entities
{
    public class Order : AuditableBaseEntity
    {
        public int TableId { get; set; }
        public int OrderStatusId { get; set; }
        public double SubTotal { get; set; }
        public Table Table { get; set; }
        public ICollection<DishOrder> DishOrders { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
