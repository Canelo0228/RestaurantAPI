using RestaurantAPI.Core.Application.Dtos.Dish;
using RestaurantAPI.Core.Application.Dtos.Table;

namespace RestaurantAPI.Core.Application.Dtos.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public TableDto Table { get; set; }
        public List<DishDto> Dishes { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; }
    }
}
