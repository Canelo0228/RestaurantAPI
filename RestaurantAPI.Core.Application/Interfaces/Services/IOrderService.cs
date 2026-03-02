using RestaurantAPI.Core.Application.Dtos.Order;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<SaveOrderDto, OrderDto, Order>
    {
    }
}
