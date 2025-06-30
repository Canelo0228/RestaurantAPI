namespace RestaurantAPI.Core.Application.Dtos.Order
{
    public class OrderSummaryDto
    {
        public int Id { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; }
    }

}
