using AutoMapper;
using OrderFoodOnlineSystem.Models;
using OrderFoodOnlineSystem.ViewModels.OrderItemViewModels;
using OrderFoodOnlineSystem.ViewModels.OrderViewModels;
using OrderFoodOnlineSystem.ViewModels.RestaurantCategoryViewModel;
using OrderFoodOnlineSystem.ViewModels.RestaurantViewModels;

namespace OrderFoodOnlineSystem.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Restaurant, RestaurantViewModel>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemViewModel>().ReverseMap();
            CreateMap<OrderItem, EditOrderItemViewModel>().ReverseMap();
            CreateMap<Order, EditOrderViewModel>().ReverseMap();
            CreateMap<RestaurantCategory, RestaurantCategoryViewModel>().ReverseMap();

        }
    }
}
