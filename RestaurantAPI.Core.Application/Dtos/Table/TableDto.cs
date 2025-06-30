using RestaurantAPI.Core.Application.Dtos.Order;

namespace RestaurantAPI.Core.Application.Dtos.Table
{
    public class TableDto
    {
        public int Id { get; set; }
        public int Capability { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        
        public List<OrderSummaryDto> Orders { get; set; }
    }

}
