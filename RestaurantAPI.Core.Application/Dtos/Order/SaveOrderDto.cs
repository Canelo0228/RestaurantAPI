namespace RestaurantAPI.Core.Application.Dtos.Order
{
    public class SaveOrderDto
    {
        public int TableId { get; set; }
        public List<int> DishIds { get; set; }
        public decimal SubTotal { get; set; }
    }
}
