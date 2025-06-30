using RestaurantAPI.Core.Application.Enums;

namespace RestaurantAPI.Core.Application.Dtos.Table
{
    public class SaveTableDto
    {
        public int Capability { get; set; }
        public string Description { get; set; }
        public TableStatus Status { get; set; } = 0;
    }

}
