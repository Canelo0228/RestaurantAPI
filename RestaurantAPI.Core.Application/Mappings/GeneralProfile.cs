using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Dish;
using RestaurantAPI.Core.Application.Dtos.Ingredient;
using RestaurantAPI.Core.Application.Dtos.Order;
using RestaurantAPI.Core.Application.Dtos.Table;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Dish
            CreateMap<Dish, DishDto>()
                .ForMember(dest => dest.Category,
                           opt => opt.MapFrom(src => src.DishCategory.Category))
                .ForMember(dest => dest.Ingredients,
                           opt => opt.MapFrom(src => src.DishIngredients
                           .Select(di => di.Ingredient)))
                .ForMember(dest => dest.Id,
                           opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.DishIngredients, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            CreateMap<Dish, SaveDishDto>()
                .ReverseMap()
                .ForMember(dest => dest.DishCategoryId, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.DishIngredients, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            #endregion

            #region Ingredient
            CreateMap<Ingredient, IngredientDto>()
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            CreateMap<Ingredient, SaveIngredientDto>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            #endregion

            #region Table
            CreateMap<Table, TableDto>()
                .ForMember(dest => dest.Orders,
                           opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Status,
                           opt => opt.MapFrom(src => src.TableStatus.Status))
                .ForMember(dest => dest.Id,
                           opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            CreateMap<Table, SaveTableDto>()
                .ReverseMap()
                .ForMember(dest => dest.StatusId, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Orders, opt => opt.Ignore());
            #endregion

            #region Order
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Status,
                           opt => opt.MapFrom
                           (
                               src => src.OrderStatus.Status
                           ))
                .ForMember(dest => dest.Dishes,
                           opt => opt.MapFrom
                           (
                               src => src.DishOrders
                               .Select(d => d.Dish)
                           ))
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            CreateMap<Order, SaveOrderDto>()
                .ForMember(dest => dest.DishIds, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.DishOrders, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DishOrders, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());
            #endregion
        }
    }
}
