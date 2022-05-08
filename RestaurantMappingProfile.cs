using AutoMapper;
using RestaurantAPI.Models;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateDishDto, Dish>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Address,
                    c => c.MapFrom(dto => new Address()
                    { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));

            CreateMap<ModifyRestaurantDto, Restaurant>()
                .ForMember(d =>d.Name, c => c.MapFrom(s => s.Name))
                .ForMember(d => d.Description, c => c.MapFrom(s => s.Description))
                .ForMember(d => d.HasDelivery, c => c.MapFrom(s => s.HasDelivery));
        }
    }
}
