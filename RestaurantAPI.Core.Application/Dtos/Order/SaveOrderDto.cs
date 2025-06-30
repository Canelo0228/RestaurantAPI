using RestaurantAPI.Core.Application.Enums;

namespace RestaurantAPI.Core.Application.Dtos.Order
{
    public class SaveOrderDto
    {
        public int TableId { get; set; }
        public List<int> DishIds { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; } = 0;
    }
}
