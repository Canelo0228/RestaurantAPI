using AutoMapper.Configuration.Annotations;

namespace RestaurantAPI.Core.Application.Dtos.Table
{
    public class SaveTableDto
    {
        public int Capability { get; set; }
        public string Description { get; set; }
    }

}
