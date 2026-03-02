using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Order;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Services
{
    public class OrderService : GenericService<SaveOrderDto, OrderDto, Order>, IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<OrderDto> AddAsync(SaveOrderDto dto)
        {
            Order order = _mapper.Map<Order>(dto);
            order.OrderStatusId = 1;

            order.DishOrders = new List<DishOrder>();
            foreach (var dishId in dto.DishIds)
            {
                order.DishOrders.Add(new DishOrder
                {
                    DishId = dishId
                });
            }

            await _repository.AddAsync(order);
            return _mapper.Map<OrderDto>(order);
        }
    }
}
