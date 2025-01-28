using AutoMapper;
using RestaurantReviewApp.Dto;
using RestaurantReviewApp.Models;

namespace RestaurantReviewApp.Util
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map Restaurant to RestaurantDto and vice versa
            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
        }
    }
}
