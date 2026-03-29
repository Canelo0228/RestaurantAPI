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
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IDishRepository dishRepository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> GetAllWithIncludesDto()
        {
            var orders = await _repository.GetAllWithIncludesAsync(new List<string>
                {
                    "OrderStatus",
                    "Table.TableStatus",
                    "DishOrders.Dish.DishCategory"
                });

            return _mapper.Map<List<OrderDto>>(orders);
        }

        public override async Task<OrderDto> AddAsync(SaveOrderDto dto)
        {
            Order order = _mapper.Map<Order>(dto);
            order.OrderStatusId = 1;
            order.DishOrders = new List<DishOrder>();

            double subTotal = 0;

            foreach (var dishId in dto.DishIds)
            {
                var dish = await _dishRepository.GetByIdAsync(dishId);

                if (dish != null)
                {
                    subTotal += dish.Price;

                    order.DishOrders.Add(new DishOrder
                    {
                        DishId = dishId
                    });
                }
                
            }

            order.SubTotal = subTotal;
            await _repository.AddAsync(order);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task UpdateAsync(UpdateOrderDto dto, int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null) throw new KeyNotFoundException();

            _mapper.Map(dto, entity);

            await _repository.UpdateAsync(entity, id);
        }

        public async Task<OrderDto> GetByIdWithIncludesAsync(int id)
        {
            var includes = new List<string>
            {
                "OrderStatus",
                "Table.TableStatus",
                "DishOrders.Dish.DishCategory"
            };
            var order = await _repository.GetByIdWithIncludesAsync(id, includes);

            if (order == null) return null;

            return _mapper.Map<OrderDto>(order);
        }
    }
}
