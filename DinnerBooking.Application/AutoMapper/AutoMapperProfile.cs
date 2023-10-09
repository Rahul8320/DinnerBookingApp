using AutoMapper;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Domain.UserAggregate;

namespace DinnerBooking.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}