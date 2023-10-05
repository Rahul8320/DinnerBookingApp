using AutoMapper;
using DinnerBooking.Application.Dtos;
using DinnerBooking.Domain.Entities;

namespace DinnerBooking.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}