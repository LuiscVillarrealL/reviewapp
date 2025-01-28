using AutoMapper;
using RestaurantReviewApp.Dto;
using RestaurantReviewApp.Models;

namespace RestaurantReviewApp.Util
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Restaurant Mappings
            CreateMap<Restaurant, RestaurantDto>();

            // Map RestaurantDto to Restaurant and ignore Id and AverageRating
            CreateMap<RestaurantDto, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AverageRating, opt => opt.Ignore());


            //User Mappings
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>()
               .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
