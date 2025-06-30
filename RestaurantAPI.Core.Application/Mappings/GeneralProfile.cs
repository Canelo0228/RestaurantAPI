using AutoMapper;
using RestaurantAPI.Core.Application.Dtos.Dish;
using RestaurantAPI.Core.Application.Dtos.Ingredient;
using RestaurantAPI.Core.Application.Dtos.Order;
using RestaurantAPI.Core.Application.Dtos.Table;
using RestaurantAPI.Core.Application.Enums;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Dish
            CreateMap<Dish, DishDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => Enum.Parse<DishCategory>(src.Category)))
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()));
            CreateMap<Dish, SaveDishDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => Enum.Parse<DishCategory>(src.Category)))
                .ForMember(dest => dest.IngredientIds, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.DishIngredients, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()));
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
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<TableStatus>(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.Orders))
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<Table, SaveTableDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<TableStatus>(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            #endregion

            #region Order
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<OrderStatus>(src.Status)))
                .ReverseMap()
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<Order, SaveOrderDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<OrderStatus>(src.Status)))
                .ForMember(dest => dest.DishIds, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Dishes, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.Ignore())
                .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            #endregion
        }
    }
}
